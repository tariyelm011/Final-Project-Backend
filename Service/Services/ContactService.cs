using AutoMapper;
using Domain.Entity;
using Repository.Repositories.Interface;
using Service.Services.Generic;
using Service.Services.Interface;
using Service.ViewModels.Contact;

namespace Service.Services;

public class ContactService : CrudService<Contact, ContactCreateVM, ContactEditVM, ContactVM>, IContactService
{
    public ContactService(IContactRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }


}
