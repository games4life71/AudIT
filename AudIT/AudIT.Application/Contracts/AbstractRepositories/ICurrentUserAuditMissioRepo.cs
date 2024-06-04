using AudiT.Domain.Entities;
using AudIT.Domain.Misc;

namespace AudIT.Applicationa.Contracts.AbstractRepositories;

public interface ICurrentUserAuditMissioRepo:IRepository<CurrentUsersAuditMission>
{
    public Task<Result<CurrentUsersAuditMission>> GetCurrentUserAuditMissionAsync(string userId);

    public Task<Result<CurrentUsersAuditMission>> SetCurrentUserAuditMissionAsync(string userId, Guid auditMissionId);

}