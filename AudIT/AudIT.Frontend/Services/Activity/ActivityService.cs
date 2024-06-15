using System.Net.Http.Json;
using Frontend.Contracts.Abstract_Services.ActivityService;
using Frontend.EntityDtos.Activity;
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

    public async Task<BaseDTOResponse<ActivityWithDepartViewModel>> CreateActivityAsync(
        CreateActivityDto createActivityViewModel)
    {
        var response =
            await httpClient.PostAsJsonAsync($"{IActivityService.ApiPath}/add-activity", createActivityViewModel);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<BaseDTOResponse<ActivityWithDepartViewModel>>(responseContent);
            if (result != null) return result;
        }
        else
        {
            return new BaseDTOResponse<ActivityWithDepartViewModel>
            {
                Success = false,
                Message = "An error occurred while creating activity"
            };
        }

        return new BaseDTOResponse<ActivityWithDepartViewModel>
        {
            Success = false,
            Message = "An error occurred while creating activity"
        };
    }

    public async Task<BaseResponse> DeleteActivityAsync(Guid id)
    {
        var response = await httpClient.DeleteAsync($"{IActivityService.ApiPath}/delete-activity/{id}");


        if (response.IsSuccessStatusCode)
        {
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<BaseResponse>(responseContent);
            if (result != null) return result;
        }
        else
        {
            return new BaseResponse
            {
                Success = false,
                Message = "An error occurred while deleting activity"
            };
        }

        return new BaseResponse
        {
            Success = false,
            Message = "An error occurred while deleting activity"
        };
    }

    public async Task<BaseDTOResponse<ActivityWithDepartViewModel>> UpdateActivityAsync(
        UpdateActivityDto updateActivityViewModel)
    {
        var response =
            await httpClient.PutAsJsonAsync($"{IActivityService.ApiPath}/update-activity", updateActivityViewModel);


        if (response.IsSuccessStatusCode)
        {
            var content = response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BaseDTOResponse<ActivityWithDepartViewModel>>(content.Result);

            if (result != null) return result;
        }

        return new BaseDTOResponse<ActivityWithDepartViewModel>
        {
            Success = false,
            Message = "An error occurred while updating activity"
        };
    }

    public async Task<BaseDTOResponse<ActivityWithDepartViewModel>> AttachDocumentAsync(Guid activityId,
        Guid baseDocumentId)
    {
        var command = new AttachDocumentToActivityDto
        {
            activityId = activityId,
            baseDocumentId = baseDocumentId
        };


        var response = await httpClient.PostAsJsonAsync($"{IActivityService.ApiPath}/attach-document", command);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BaseDTOResponse<ActivityWithDepartViewModel>>(content);

            if (result != null) return result;
        }

        return new BaseDTOResponse<ActivityWithDepartViewModel>
        {
            Success = false,
            Message = "An error occurred while attaching document to activity"
        };
    }
}