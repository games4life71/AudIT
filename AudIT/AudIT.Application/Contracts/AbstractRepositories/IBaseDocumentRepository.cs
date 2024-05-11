using AudiT.Domain.Entities;
using AudIT.Domain.Misc;

namespace AudIT.Applicationa.Contracts.AbstractRepositories;

public interface IBaseDocumentRepository : IRepository<BaseDocument>
{
    Task<Result<List<StandaloneDocument>>> GetDocumentsByDepartmentId(Guid requestDepartmentId);
    Task<Result<List<BaseDocument>>> GetDocumentsByUserId(Guid requestUserId);
}