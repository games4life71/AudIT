using AudiT.Domain.Entities;
using AudIT.Domain.Misc;

namespace AudIT.Applicationa.Contracts.AbstractRepositories;

public interface IObjectiveRepository : IRepository<Objective>
{
    public Task<Result<List<Objective>>> FindAllByAuditMissionIdAsync(Guid auditMissionId);

    public Task<Result<List<Objective>>> FindMostRecentsByAuditMissionIdAsync(Guid auditMissionId);


    public Task<Result<Objective>>  FindObjectiveByObjectiveActionId(Guid requestRecommendationId);
}