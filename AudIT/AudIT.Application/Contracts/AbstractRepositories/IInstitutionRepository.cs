using AudiT.Domain.Entities;
using AudIT.Domain.Misc;

namespace AudIT.Applicationa.Contracts.AbstractRepositories;

public interface IInstitutionRepository: IRepository<Institution>
{

    public Task<Result<Institution>> FindInstitutionByDomainAsync(string domain);


    public Task<Result<List<Institution>>> GetAllInstitutionsFullAsync();
    public Task<Result<Institution>> GetInstitutionByAuditMissionId(Guid valueAuditMissionId);

}