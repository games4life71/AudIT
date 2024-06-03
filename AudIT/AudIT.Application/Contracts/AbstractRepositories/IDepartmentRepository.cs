using AudiT.Domain.Entities;
using AudIT.Domain.Misc;

namespace AudIT.Applicationa.Contracts.AbstractRepositories;

public interface IDepartmentRepository : IRepository<Department>
{
    public Task<Result<List<Department>>> FindAllByInstitutionIdAsync(Guid institutionId);
}