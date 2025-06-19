using Domain.Entity;
using Service.Dtos.Expert;
using Service.Services.Interface.Generic;

namespace Service.Services.Interface;

public interface IExpertService : ICrudService<Expert, ExpertCreateVM, ExpertEditVM, ExpertVM>
{
    Task<ExpertEditVM> ExpertUpdateAsyncVM(int id);
    Task CreateAsync(ExpertCreateVM vm);
    Task UpdateAsync(ExpertEditVM vm);
}
