using Service.ViewModels.Payment;

namespace Service.Services.Interface;

public interface IPaymentService
{
    Task<PaymentResponseVM> CreateAsync(PaymentCreateVM dto);
    Task<bool> CheckPaymentAsync(PaymentCheckVM dto);
}
