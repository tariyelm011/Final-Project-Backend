using Domain.Entity;
using Service.Dtos.Expert;
using Service.Services.Interface.Generic;

namespace Service.Services.Interface;

public interface IExpertService : ICrudService<Expert, ExpertCreateVM, ExpertEditVM, ExpertVM>
{
    Task<ExpertEditVM> ExpertsAsync(int id);
    Task CreateExpert(ExpertCreateVM vm);
    Task UpdateExpert(ExpertEditVM vm);
}
