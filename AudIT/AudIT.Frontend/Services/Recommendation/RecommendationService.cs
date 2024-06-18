using System.Net.Http.Json;
using Frontend.Contracts.Abstract_Services.RecommendationService;
using Frontend.EntityDtos.Misc;
using Frontend.EntityDtos.Recommendation;
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

    public async Task<BaseDTOResponse<BaseRecommendationViewModel>> UpdateRecommendationAsync(
        UpdateRecommendationDto updateRecommendationDto)
    {
        var rsponse = await httpClient.PutAsJsonAsync($"{IRecommendationService.ApiPath}/update-recommendation",
            updateRecommendationDto);


        if (!rsponse.IsSuccessStatusCode)
        {
            return new BaseDTOResponse<BaseRecommendationViewModel>("Failed to update", false);
        }

        var content = await rsponse.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseRecommendationViewModel>>(content);

        return result ?? new BaseDTOResponse<BaseRecommendationViewModel>("Failed to update", false);
    }

    public async Task<BaseResponse> DeleteRecommendationAsync(Guid id)
    {
        var response = await httpClient.DeleteAsync($"{IRecommendationService.ApiPath}/delete-recommendation/{id}");

        if (!response.IsSuccessStatusCode)
        {
            return new BaseResponse("Failed to delete", false);
        }

        return new BaseResponse("Deleted successfully", true);
    }
}