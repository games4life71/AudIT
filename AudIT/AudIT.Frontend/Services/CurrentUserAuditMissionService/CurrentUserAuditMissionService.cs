using Frontend.Contracts.Abstract_Services.CurrentUserAuditMissionService;
using Frontend.EntityDtos.Misc;
using Frontend.EntityViewModels.CurrentUserAuditMissionViewModel;
using Newtonsoft.Json;

namespace Frontend.Services.CurrentUserAuditMissionService;

public class CurrentUserAuditMissionService(HttpClient httpClient) :
    ICurrentUserAuditMissionService
{
    public async Task<BaseDTOResponse<CurrentUserAuditMissionViewModel>> GetCurrentUserAuditMissionAsync()
    {
        var response =
            await httpClient.GetAsync($"{ICurrentUserAuditMissionService.ApiPath}/get-current-user-audit-mission");

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var result =
                JsonConvert.DeserializeObject<BaseDTOResponse<CurrentUserAuditMissionViewModel>>(responseContent);
            if (result != null) return result;
        }
        else
        {
            if (response.ReasonPhrase != null)
                return new BaseDTOResponse<CurrentUserAuditMissionViewModel>(response.ReasonPhrase);
        }

        return new BaseDTOResponse<CurrentUserAuditMissionViewModel>(
            "An error occurred while fetching the current user's audit mission. Please try again later.");
    }
}