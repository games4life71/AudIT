using AudiT.Domain.Entities;
using AudIT.Domain.Misc;

namespace AudIT.Applicationa.Contracts.AbstractRepositories;

public interface IRecommendationRepository:IRepository<Recommendation>
{


    public Task<Result<Recommendation>> FindByIdWithObjectiveActionAsync(Guid id);

    public Task<Result<Recommendation>> UpdateStatusAsync(Guid id,Status newStatus);

}