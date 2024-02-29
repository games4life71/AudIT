using AudiT.Domain.Entities;
using AudIT.Domain.Misc;

namespace AudIT.Applicationa.Contracts.AbstractRepositories;

public interface IObjectiveActionRepository:IRepository<ObjectiveAction>
{

    public Task<Result<ObjectiveAction>> FindByIdAsyncWithActionRisks(Guid id);


}