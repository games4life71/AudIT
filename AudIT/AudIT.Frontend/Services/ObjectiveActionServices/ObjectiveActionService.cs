using System.Net.Http.Json;
using Frontend.Contracts.Abstract_Services.ObjectiveActionService;
using Frontend.EntityDtos.Misc;
using Frontend.EntityDtos.ObjectiveAction;
using Frontend.EntityViewModels.Objective;
using Frontend.EntityViewModels.ObjectiveAction;
using Newtonsoft.Json;

namespace Frontend.Services.ObjectiveActionServices;

public class ObjectiveActionService(HttpClient httpClient) : IObjectiveActionService
{
    public async Task<BaseDTOResponse<BaseObjectiveActionViewModel>> CreateObjectiveActionAsync(
        CreateObjectiveActionDto createObjectiveActionDto)
    {
        var response = await httpClient.PostAsJsonAsync($"{IObjectiveActionService.ApiPath}/add-new-objective-action",
            createObjectiveActionDto);

        if (!response.IsSuccessStatusCode)
        {
            return new BaseDTOResponse<BaseObjectiveActionViewModel>
            {
                Success = false,
                Message = response.ReasonPhrase
            };
        }

        var content = await response.Content.ReadAsStringAsync();

        try
        {
            var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseObjectiveActionViewModel>>(content);
            if (result != null) return result;
        }
        catch (JsonSerializationException ex)
        {
            Console.WriteLine(ex.Message);
        }


        return new BaseDTOResponse<BaseObjectiveActionViewModel>
        {
            Success = false,
            Message = "An error occurred while fetching the data."
        };
    }

    public async Task<BaseDTOResponse<BaseObjectiveActionViewModel>> UpdateObjActionControlsSelectedAsync(
        UpdateObjActionControlsSelectedDto updateObjActionControlsSelectedDto)
    {
        var postResponse = await httpClient.PatchAsJsonAsync(
            $"{IObjectiveActionService.ApiPath}/update-objective-action-controls",
            updateObjActionControlsSelectedDto);


        if (!postResponse.IsSuccessStatusCode)
            return new BaseDTOResponse<BaseObjectiveActionViewModel>
            {
                Success = false,
                Message = postResponse.ReasonPhrase
            };


        var result = await postResponse.Content.ReadFromJsonAsync<BaseDTOResponse<BaseObjectiveActionViewModel>>();

        if (result != null) return result;

        return new BaseDTOResponse<BaseObjectiveActionViewModel>
        {
            Success = false,
            Message = "An error occurred while fetching the data."
        };
    }

    public async Task<BaseDTOResponse<ObjectiveActionViewModel>> GetObjectiveActionByIdAsync(Guid id)
    {
        var responseResult = await httpClient.GetAsync($"{IObjectiveActionService.ApiPath}/get-objective-action/{id}");

        if (responseResult.IsSuccessStatusCode)
        {
            var content = await responseResult.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BaseDTOResponse<ObjectiveActionViewModel>>(content);
            if (result != null) return result;
        }

        return new BaseDTOResponse<ObjectiveActionViewModel>
        {
            Success = false,
            Message = "An error occurred while fetching the data."
        };
    }

    public async Task<BaseDTOResponse<ObjectiveActionViewModel>> GetObjectiveActionByObjectiveIdAsync(Guid id)
    {
        var resposne = await httpClient.GetAsync($"{IObjectiveActionService.ApiPath}/get-objective-actions/{id}");

        if (resposne.IsSuccessStatusCode)
        {
            var content = await resposne.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BaseDTOResponse<ObjectiveActionViewModel>>(content);
            if (result != null) return result;
        }

        return new BaseDTOResponse<ObjectiveActionViewModel>
        {
            Success = false,
            Message = "An error occurred while fetching the data."
        };
    }
}