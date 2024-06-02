using AudiT.Domain.Entities;
using AudIT.Domain.Misc;

namespace AudIT.Applicationa.Contracts.AbstractRepositories;

public interface IUserInstitutionRepository:IRepository<UserInstitution>
{
    Task<Result<List<User>>> GetAllUsersByInstitutionId(Guid institutionId);
}