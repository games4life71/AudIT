using AudiT.Domain.Entities;
using AudIT.Domain.Misc;

namespace AudIT.Applicationa.Contracts.AbstractRepositories;

public interface IRecommendationDocumentRepository:IRepository<RecommendationDocument>
{
    public Task<Result<List<RecommendationDocument>>> FindByRecommendationId(Guid recommendationId);
}