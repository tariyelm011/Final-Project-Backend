using Domain.Entity;
using Domain.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Repository.Repositories.Interface;
using Service.Helpers.Exceptions;
using Service.Services.Interface;
using Service.ViewModels.Payment;
using System.Text;

namespace Service.Services;

public class PaymentService : IPaymentService
{
    private readonly IConfiguration _configuration;
    private readonly PaymentConfigurationVM _paymentConfigurationDto;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IUrlHelper _urlHelper;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IPaymentRepository _repository;

    public PaymentService(IConfiguration configuration, IUrlHelperFactory urlHelperFactory, IActionContextAccessor actionContextAccessor, IHttpContextAccessor contextAccessor, IHttpClientFactory httpClientFactory, IPaymentRepository repository)
    {
        _configuration = configuration;
        _paymentConfigurationDto = _configuration.GetSection("PaymentSettings").Get<PaymentConfigurationVM>() ?? new();
        _urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext ?? new());
        _contextAccessor = contextAccessor;
        _httpClientFactory = httpClientFactory;

        _repository = repository;
    }

    public async Task<bool> CheckPaymentAsync(PaymentCheckVM dto)
    {
        var payment = await _repository.GetAsync(x => x.ConfirmToken == dto.Token && x.ReceptId == dto.ID && x.PaymentStatus == PaymentStatuses.Pending, include: x => x.Include(x => x.Order));
        if (payment is null)
            throw new NotFoundException();

        if (dto.STATUS == PaymentStatuses.FullyPaid)
            payment.Order.IsPaid = true;

        payment.PaymentStatus = dto.STATUS;

        _repository.Update(payment);
        await _repository.SaveChangesAsync();

        return dto.STATUS == PaymentStatuses.FullyPaid;
    }

    public async Task<PaymentResponseVM> CreateAsync(PaymentCreateVM dto)
    {
        string confirmToken = Guid.NewGuid().ToString();

        UrlActionContext context = new()
        {
            Action = "CheckPayment",
            Controller = "Checkout",
            Values = new { Token = confirmToken },
            Protocol = _contextAccessor.HttpContext?.Request.Scheme
        };

        var redirectUrl = _urlHelper.Action(context);



        string amount = dto.Amount.ToString().Replace(',', '.');


        string requestBody = $@"
    {{
        ""order"": {{
            ""typeRid"": ""Order_SMS"",
            ""amount"": {amount},
            ""currency"": ""AZN"",
            ""language"": ""{"az"}"",
            ""description"": ""{dto.Description}"",
            ""hppRedirectUrl"": ""{redirectUrl}"",
            ""hppCofCapturePurposes"": [""Cit""]
        }}
    }}";

        var httpClient = _httpClientFactory.CreateClient("KapitalBankClient");
        var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_paymentConfigurationDto.Username}:{_paymentConfigurationDto.Password}"));
        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);


        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(_paymentConfigurationDto.BaseUrl, content);

        if (!response.IsSuccessStatusCode)
            throw new Exception(response.StatusCode.ToString());

        var responseContent = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<PaymentResponseVM>(responseContent) ?? new();

        Payment payment = new()
        {
            Amount = dto.Amount,
            Description = dto.Description,
            ReceptId = result.Order.Id,
            OrderId = dto.OrderId,

            SecretId = result.Order.Secret,
            PaymentStatus = PaymentStatuses.Pending,
            ConfirmToken = confirmToken
        };

        await _repository.CreateAsync(payment);
        await _repository.SaveChangesAsync();

        result.Id = payment.Id;

        return result;
    }
}
