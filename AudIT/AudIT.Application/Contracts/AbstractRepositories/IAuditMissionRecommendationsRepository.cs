using AudiT.Domain.Entities;
using AudIT.Domain.Misc;

namespace AudIT.Applicationa.Contracts.AbstractRepositories;

public interface IAuditMissionRecommendationsRepository:IRepository<AuditMissionRecommendations>
{
    public  Task<Result<List<Recommendation>>> FindAllByAuditMissionIdAsync(Guid requestAuditMissionId);
    Task<(string,bool)> DeleteByRecommendationId(Guid requestId);
    Task<Result<List<Recommendation>>> GetRecommendationsByInstitutionId(Guid valueInstitutionId);

    Task<Result<AuditMissionRecommendations>> GetAuditMissionByRecommendationId(Guid recommendationId);

}