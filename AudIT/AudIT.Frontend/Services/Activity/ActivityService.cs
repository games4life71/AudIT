using Frontend.Contracts.Abstract_Services.ActivityService;
using Frontend.EntityDtos.Misc;
using Frontend.EntityViewModels.Activity;
using Newtonsoft.Json;

namespace Frontend.Services.Activity;

public class ActivityService(HttpClient httpClient) : IActivityService
{
    public async Task<BaseDTOResponse<BaseActivityViewmodel>> GetActivitiesByAuditMissionIdAsync(Guid auditMissionId)
    {
        var response =
            await httpClient.GetAsync(
                $"{IActivityService.ApiPath}/get-activities-by-audit-mission/{auditMissionId}?mostRecent=false");

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseActivityViewmodel>>(responseContent);
            if (result != null) return result;
        }
        else
        {
            return new BaseDTOResponse<BaseActivityViewmodel>
            {
                Success = false,
                Message = "An error occurred while fetching activities"
            };
        }

        return new BaseDTOResponse<BaseActivityViewmodel>
        {
            Success = false,
            Message = "An error occurred while fetching activities"
        };
    }

    public async Task<BaseDTOResponse<BaseActivityViewmodel>> GetRecentActivitiesByAuditMissionIdAsync(
        Guid auditMissionId)
    {
        var response =
            await httpClient.GetAsync(
                $"{IActivityService.ApiPath}/get-activities-by-audit-mission/{auditMissionId}?mostRecent=true");

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseActivityViewmodel>>(responseContent);
            if (result != null) return result;
        }
        else
        {
            return new BaseDTOResponse<BaseActivityViewmodel>
            {
                Success = false,
                Message = "An error occurred while fetching activities"
            };
        }

        return new BaseDTOResponse<BaseActivityViewmodel>
        {
            Success = false,
            Message = "An error occurred while fetching activities"
        };
    }

    public async Task<BaseDTOResponse<ActivityWithDepartViewModel>> GetActivitiesByObjectiveActionIdAsync(
        Guid objectiveActionId)
    {
        var response = await
            httpClient.GetAsync($"{IActivityService.ApiPath}/get-activities-by-objective-action/{objectiveActionId}");


        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BaseDTOResponse<ActivityWithDepartViewModel>>(content);

            if (result != null) return result;
        }

        return new BaseDTOResponse<ActivityWithDepartViewModel>(response.ReasonPhrase);
    }
}