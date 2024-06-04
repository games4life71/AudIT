using Frontend.Contracts.Abstract_Services.FiapService;
using Frontend.EntityDtos.Misc;
using Frontend.EntityViewModels.Fiap;
using Newtonsoft.Json;

namespace Frontend.Services.FiapService;

public class FiapService(HttpClient httpClient) : IFiapService
{
    public async Task<BaseDTOResponse<BaseObjActionFiapViewmodel>> GetRecentFiapsByAudidMissionAsync(Guid audiMissionId)
    {
        var response =
            await httpClient.GetAsync(
                $"{IFiapService.ApiPath}/get-obj-action-fiap-by-audit-mission-id/{audiMissionId}?mostRecent=true");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseObjActionFiapViewmodel>>(content);
            if (result != null) return result;
        }
        else
        {
            return new BaseDTOResponse<BaseObjActionFiapViewmodel>
            {
                Success = false,
                Message = response.ReasonPhrase
            };
        }

        return new BaseDTOResponse<BaseObjActionFiapViewmodel>
        {
            Success = false,
            Message = "An error occurred while fetching data"
        };
    }

    public async Task<BaseDTOResponse<BaseObjActionFiapViewmodel>> GetFiapsByAudidMissionAsync(Guid audiMissionId)
    {
        var response =
            await httpClient.GetAsync(
                $"{IFiapService.ApiPath}/get-obj-action-fiap-by-audit-mission-id/{audiMissionId}?mostRecent=false");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseObjActionFiapViewmodel>>(content);
            if (result != null) return result;
        }
        else
        {
            return new BaseDTOResponse<BaseObjActionFiapViewmodel>
            {
                Success = false,
                Message = response.ReasonPhrase
            };
        }

        return new BaseDTOResponse<BaseObjActionFiapViewmodel>
        {
            Success = false,
            Message = "An error occurred while fetching data"
        };
    }

    public async Task<BaseDTOResponse<BaseObjActionFiapViewmodel>> GetFiapByObjectiveActionIdAsync(
        Guid objectiveActionId)
    {
        var response = await httpClient.GetAsync(
            $"{IFiapService.ApiPath}/get-obj-action-fiap-by-obj-action-id/{objectiveActionId}");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseObjActionFiapViewmodel>>(content);

            if (result != null) return result;
        }

        return new BaseDTOResponse<BaseObjActionFiapViewmodel>
        {
            Success = false,
            Message = "An error occurred while fetching data"
        };
    }
}