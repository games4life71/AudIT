using System.Net;
using System.Net.Http.Json;
using Frontend.Contracts.Abstract_Services.ActionRiskService;
using Frontend.EntityDtos.ActionRisk;
using Frontend.EntityDtos.Misc;
using Frontend.EntityViewModels.ActionRisk;

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
}