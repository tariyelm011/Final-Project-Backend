using AutoMapper;
using Domain.Entity;
using Repository.Repositories.Interface;
using Service.Helpers.Exceptions;
using Service.Services.Generic;
using Microsoft.AspNetCore.Hosting;

using Service.Services.Interface;
using Service.ViewModels.Contact;

namespace Service.Services;

public class ContactService : CrudService<Contact, ContactCreateVM, ContactEditVM, ContactVM>, IContactService
{
    private readonly IContactRepository _contactRepository;
    private readonly IEmailService _emailService;
    public ContactService(IContactRepository repository, IMapper mapper, IEmailService emailService) : base(repository, mapper)
    {
        _contactRepository = repository;
        _emailService = emailService;
    }

    public async Task<ContactCreateVM> ContactCreateVMAsync(int id)
    {
        var model = await _contactRepository.GetAsync(id);

        if (model == null)
        {
            throw new NotFoundException();
        }

        var vm = new ContactCreateVM { Name = model.Name, Email = model.Email, Message = model.Message, Id = model.Id  , PhoneNumber = model.PhoneNumber};

        return vm;
    }

    public async Task<bool> SendEmailContact(ContactCreateVM vm)
    {
        if (vm == null)
        {
            throw new NotFoundException();
        }



        _emailService.SendEmail(vm.Email, "Dear Customer", vm.Answer);

        var model = await _contactRepository.GetAsync(vm.Id);
        if (model == null)
        {
            throw new NotFoundException();
        }

        model.IsAnswer = true;

        _contactRepository.Update(model);
        await _contactRepository.SaveChangesAsync();

        return true;
    }

}
