using Frontend.EntityDtos.Misc;
using Frontend.EntityDtos.Recommendation;
using Frontend.EntityViewModels.Recommendation;
using Frontend.EntityViewModels.RecommendationDocument;

namespace Frontend.Contracts.Abstract_Services.RecommendationService;

public interface IRecommendationService
{
    public const string ApiPath = "https://localhost:7248/api/Recommendation";

    public Task<BaseDTOResponse<BaseRecommendationViewModel>> FindAllByAuditMissionIdAsync(Guid requestAuditMissionId);

    public Task<BaseDTOResponse<BaseRecommendationViewModel>> UpdateRecommendationAsync(UpdateRecommendationDto updateRecommendationDto);


    public Task<BaseResponse> DeleteRecommendationAsync(Guid id);


    public Task<BaseDTOResponse<BaseRecommendationViewModel>> CreateRecommendationAsync(CreateRecommendationDto createRecommendationDto);

    public Task<BaseDTOResponse<BaseRecommendationViewModel>> GetAllRecentByUserAsync();

    public Task<BaseResponse> CreateRecommendationDocument(RecommendationDocumentViewModel recommendationDocumentViewModel);

}