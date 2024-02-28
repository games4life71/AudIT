using AudiT.Domain.Entities;
using AudIT.Domain.Misc;

namespace AudIT.Applicationa.Contracts.AbstractRepositories;

public interface IAuditMissionRepository : IRepository<AuditMission>
{
    public Task<Result<IReadOnlyList<AuditMission>>> GetByOwnerId(string id);

    Task<Result<IReadOnlyList<AuditMission>>> GetByDepartmentId(Guid requestDepartmentId);
}