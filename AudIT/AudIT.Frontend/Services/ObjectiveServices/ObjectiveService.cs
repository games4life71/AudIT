using System.Net.Http.Json;
using Frontend.Contracts.Abstract_Services.ObjectiveService;
using Frontend.EntityDtos.Misc;
using Frontend.EntityDtos.Objective;
using Frontend.EntityViewModels.Objective;

namespace Frontend.Services.ObjectiveServices;

public class ObjectiveService(HttpClient httpClient) : IObjectiveService
{
    public async Task<BaseDTOResponse<BaseObjectiveViewModel>> GetMostRecentObjectiveByAuditMissionIdAsync(
        Guid auditMissionId)
    {
        var response =
            await httpClient.GetAsync(
                $"{IObjectiveService.ApiPath}/get-most-recent-objective-by-audit-mission-id/?auditMissionId={auditMissionId}");

        if (!response.IsSuccessStatusCode)
        {
            return new BaseDTOResponse<BaseObjectiveViewModel>
            {
                Success = false,
                Message = response.ReasonPhrase
            };
        }

        var result = await response.Content.ReadFromJsonAsync<BaseDTOResponse<BaseObjectiveViewModel>>();

        if (result != null) return result;

        return new BaseDTOResponse<BaseObjectiveViewModel>
        {
            Success = false,
            Message = "An error occurred while fetching the data."
        };
    }

    public async Task<BaseDTOResponse<BaseObjectiveViewModel>> GetObjectivesByAuditMissionIdAsync(Guid auditMissionId)
    {
        var response = await
            httpClient.GetAsync(
                $"{IObjectiveService.ApiPath}/get-objective-by-audit-mission-id?auditMissionId={auditMissionId}");

        if (!response.IsSuccessStatusCode)
        {
            return new BaseDTOResponse<BaseObjectiveViewModel>
            {
                Success = false,
                Message = response.ReasonPhrase
            };
        }

        var result = await response.Content.ReadFromJsonAsync<BaseDTOResponse<BaseObjectiveViewModel>>();

        if (result != null) return result;

        return new BaseDTOResponse<BaseObjectiveViewModel>
        {
            Success = false,
            Message = "An error occurred while fetching the data."
        };
    }

    public async Task<BaseDTOResponse<ObjectiveFullViewModel>> GetObjectiveWithActionsByIdAsync(Guid objectiveId)
    {
        var response = await httpClient.GetAsync($"{IObjectiveService.ApiPath}/get-objective-by-id/?id={objectiveId}");

        if (!response.IsSuccessStatusCode)
        {
            return new BaseDTOResponse<ObjectiveFullViewModel>
            {
                Success = false,
                Message = response.ReasonPhrase
            };
        }

        var result = await response.Content.ReadFromJsonAsync<BaseDTOResponse<ObjectiveFullViewModel>>();

        if (result != null) return result;

        return new BaseDTOResponse<ObjectiveFullViewModel>
        {
            Success = false,
            Message = "An error occurred while fetching the data."
        };
    }

    public async Task<BaseDTOResponse<ObjectiveFullViewModel>> GetObjectiveFullByAuditMissionIdAsync(
        Guid auditMissionId)
    {
        //first get all basic objectives

        var objectives = await GetObjectivesByAuditMissionIdAsync(auditMissionId);
        List<ObjectiveFullViewModel> objectivesFull = [];
        if (objectives.Success)
        {
            foreach (var objective in objectives.DtoResponses)
            {
                var objectiveFull = await GetObjectiveWithActionsByIdAsync(objective.Id);

                if (objectiveFull is { Success: true, DtoResponse: not null })
                {
                    objectivesFull.Add(objectiveFull.DtoResponse);
                }
            }

            return new BaseDTOResponse<ObjectiveFullViewModel>(objectivesFull, "", true);
        }

        return new BaseDTOResponse<ObjectiveFullViewModel>
        {
            Success = false,
            Message = "An error occurred while fetching the data."
        };
    }

    public async Task<BaseResponse> DeleteObjectiveAsync(Guid objectiveId)
    {
        var response = await httpClient.DeleteAsync($"{IObjectiveService.ApiPath}/delete-objective/{objectiveId}");

        if (!response.IsSuccessStatusCode)
        {
            return new BaseResponse
            {
                Success = false,
                Message = response.ReasonPhrase
            };
        }

        return new BaseResponse
        {
            Success = true,
            Message = "Objective deleted successfully."
        };
    }

    public async Task<BaseDTOResponse<BaseObjectiveViewModel>> UpdateObjectiveAsync(UpdateObjectiveNameDto updateDto)
    {
        var response =
            await httpClient.PatchAsJsonAsync($"{IObjectiveService.ApiPath}/update-objective-name", updateDto);

        if (!response.IsSuccessStatusCode)
        {
            return new BaseDTOResponse<BaseObjectiveViewModel>
            {
                Success = false,
                Message = response.ReasonPhrase
            };
        }

        var result = await response.Content.ReadFromJsonAsync<BaseDTOResponse<BaseObjectiveViewModel>>();

        if (result != null) return result;

        return new BaseDTOResponse<BaseObjectiveViewModel>
        {
            Success = false,
            Message = "An error occurred while fetching the data."
        };
    }

    public async Task<BaseDTOResponse<BaseObjectiveViewModel>> CreateObjectiveAsync(
        CreateObjectiveDto createObjectiveDto)
    {
        var response =
            await httpClient.PostAsJsonAsync($"{IObjectiveService.ApiPath}/add-new-objective", createObjectiveDto);

        if (!response.IsSuccessStatusCode)
        {
            return new BaseDTOResponse<BaseObjectiveViewModel>
            {
                Success = false,
                Message = response.ReasonPhrase
            };
        }

        var result = await response.Content.ReadFromJsonAsync<BaseDTOResponse<BaseObjectiveViewModel>>();

        if (result != null) return result;

        return new BaseDTOResponse<BaseObjectiveViewModel>
        {
            Success = false,
            Message = "An error occurred while fetching the data."
        };
    }
}