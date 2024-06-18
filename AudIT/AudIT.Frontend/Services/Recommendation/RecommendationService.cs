using Frontend.Contracts.Abstract_Services.RecommendationService;
using Frontend.EntityDtos.Misc;
using Frontend.EntityViewModels.Recommendation;
using Newtonsoft.Json;

namespace Frontend.Services.Recommendation;

public class RecommendationService(HttpClient httpClient) : IRecommendationService
{
    public async Task<BaseDTOResponse<BaseRecommendationViewModel>> FindAllByAuditMissionIdAsync(
        Guid requestAuditMissionId)
    {
        var response =
            await httpClient.GetAsync(
                $"{IRecommendationService.ApiPath}/get-all-by-audit-mission/{requestAuditMissionId}");

        if (!response.IsSuccessStatusCode)
        {
            return new BaseDTOResponse<BaseRecommendationViewModel>("Failed to fetch", false);
        }

        var content = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseRecommendationViewModel>>(content);

        return result ?? new BaseDTOResponse<BaseRecommendationViewModel>("Failed to fetch", false);
    }
}