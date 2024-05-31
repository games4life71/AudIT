using System.Net.Http.Json;
using Frontend.Contracts.Abstract_Services.ObjectiveService;
using Frontend.EntityDtos.Misc;
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
        throw new NotImplementedException();
    }
}