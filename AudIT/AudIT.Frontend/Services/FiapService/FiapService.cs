using System.Net.Http.Json;
using Frontend.Contracts.Abstract_Services.FiapService;
using Frontend.EntityDtos.Fiap;
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

    public async Task<BaseResponse> DeleteFiapAsync(Guid id)
    {
        var response = await httpClient.DeleteAsync($"{IFiapService.ApiPath}/delete-obj-action-fiap/{id}");

        if (response.IsSuccessStatusCode)
        {
            return new BaseResponse("Succes", true);
        }

        return new BaseResponse(response.ReasonPhrase, false);
    }

    public async Task<BaseDTOResponse<BaseObjActionFiapViewmodel>> CreateFiapAsync(BaseCreateFiapDto fiap)
    {
        var response = await httpClient.PostAsJsonAsync(
            $"{IFiapService.ApiPath}/create-obj-action-fiap", fiap);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseObjActionFiapViewmodel>>(content);

            if (result != null) return result;
        }

        return new BaseDTOResponse<BaseObjActionFiapViewmodel>
        {
            Success = false,
            Message = "An error occurred while posting data:" + response.ReasonPhrase
        };
    }

    public async  Task<BaseDTOResponse<BaseObjActionFiapViewmodel>> UpdateFiapAsync(UpdateFiapDto fiap)
    {

        var response = await httpClient.PutAsJsonAsync($"{IFiapService.ApiPath}/update-obj-action-fiap", fiap);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseObjActionFiapViewmodel>>(content);

            if (result != null) return result;
        }

        return new BaseDTOResponse<BaseObjActionFiapViewmodel>
        {
            Success = false,
            Message = "An error occurred while updating data:" + response.ReasonPhrase
        };


    }
}