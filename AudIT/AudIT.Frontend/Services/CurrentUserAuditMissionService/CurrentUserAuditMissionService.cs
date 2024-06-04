using System.Net.Http.Json;
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

    public async Task<BaseDTOResponse<CurrentUserAuditMissionViewModel>> SetCurrentUserAuditMissionAsync(
        Guid AuditMissionId)
    {
        var respone = await
            httpClient.PostAsync(
                $"{ICurrentUserAuditMissionService.ApiPath}/" +
                $"set-current-user-audit-mission?auditMissionId={AuditMissionId}", new StringContent(""));

        if (respone.IsSuccessStatusCode)
        {
            //read the response content
            var responseContent = await respone.Content.ReadAsStringAsync();
            //deserialize the response content
            var result =
                JsonConvert.DeserializeObject<BaseDTOResponse<CurrentUserAuditMissionViewModel>>(responseContent);

            if (result != null) return result;
        }
        else
        {
            return new BaseDTOResponse<CurrentUserAuditMissionViewModel>()
            {
                Success = false,
                Message = respone.ReasonPhrase
            };
        }

        return new BaseDTOResponse<CurrentUserAuditMissionViewModel>()
        {
            Success = false,
            Message = "An error occurred while setting the current user's audit mission. Please try again later."
        };
    }
}