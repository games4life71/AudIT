using System.Net;
using System.Net.Http.Json;
using Frontend.Contracts.Abstract_Services.ActionRiskService;
using Frontend.EntityDtos.ActionRisk;
using Frontend.EntityDtos.Misc;
using Frontend.EntityViewModels.ActionRisk;
using Frontend.EntityViewModels.ObjectiveAction;

namespace Frontend.Services.ActionRiskServices;

public class ActionRiskService(HttpClient httpClient) : IActionRiskService
{
    public async Task<BaseDTOResponse<ActionRiskViewModel>> UpdateActionRisk(UpdateActionRiskDto updateActionRiskDto)
    {
        var updateResponse = await httpClient
            .PutAsJsonAsync($"{IActionRiskService.ApiPath}/update-objective-action-risk",
                updateActionRiskDto);

        if (!updateResponse.IsSuccessStatusCode)
        {
            return new BaseDTOResponse<ActionRiskViewModel>()
            {
                Success = false,
                Message = updateResponse.ReasonPhrase
            };
        }

        var updatedActionRisk = await updateResponse.Content.ReadFromJsonAsync<BaseDTOResponse<ActionRiskViewModel>>();

        if (updatedActionRisk == null)
        {
            return new BaseDTOResponse<ActionRiskViewModel>()
            {
                Success = false,
                Message = "An error occurred while updating the action risk"
            };
        }

        return updatedActionRisk;
    }

    public async Task<BaseDTOResponse<ObjActionWithRisksViewModel>> CreateActionRiskAsync(
        CreateActionRiskDto createActionRiskDto)
    {
        var createResponse = await httpClient
            .PostAsJsonAsync($"{IActionRiskService.ApiPath}/add-action-risk",
                createActionRiskDto);

        if (!createResponse.IsSuccessStatusCode)
            return new BaseDTOResponse<ObjActionWithRisksViewModel>()
            {
                Success = false,
                Message = createResponse.ReasonPhrase
            };

        var createdActionRisk =
            await createResponse.Content.ReadFromJsonAsync<BaseDTOResponse<ObjActionWithRisksViewModel>>();

        if (createdActionRisk != null) return createdActionRisk;

        return new BaseDTOResponse<ObjActionWithRisksViewModel>()
        {
            Success = false,
            Message = "An error occurred while creating the action risk"
        };
    }

    public async Task<BaseResponse> DeleteActionRiskAsync(Guid actionRiskId)
    {
        var response = await httpClient.DeleteAsync($"{IActionRiskService.ApiPath}/delete-action-risk/{actionRiskId}");


        if (response.IsSuccessStatusCode)
        {
            return new BaseResponse()
            {
                Success = true
            };
        }

        return new BaseResponse()
        {
            Success = false,
            Message = response.ReasonPhrase
        };
    }
}