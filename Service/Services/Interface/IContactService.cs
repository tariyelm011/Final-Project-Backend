using Domain.Entity;
using Service.Services.Interface.Generic;
using Service.ViewModels.Contact;

namespace Service.Services.Interface;

public interface IContactService : ICrudService<Contact, ContactCreateVM, ContactEditVM, ContactVM>
{
    Task<ContactCreateVM> ContactCreateVMAsync(int id);
    Task<bool> SendEmailContact(ContactCreateVM vm);
}