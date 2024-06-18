using Frontend.EntityDtos.Misc;
using Frontend.EntityViewModels.Recommendation;

namespace Frontend.Contracts.Abstract_Services.RecommendationService;

public interface IRecommendationService
{
    public const string ApiPath = "https://localhost:7248/api/Recommendation";

    public Task<BaseDTOResponse<BaseRecommendationViewModel>> FindAllByAuditMissionIdAsync(Guid requestAuditMissionId);
}