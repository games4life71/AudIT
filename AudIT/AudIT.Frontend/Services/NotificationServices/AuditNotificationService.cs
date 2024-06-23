using System.Net.Http.Json;
using Frontend.Contracts.Abstract_Services.Notification;
using Frontend.EntityDtos.Misc;
using Frontend.EntityDtos.Notification;
using Frontend.EntityViewModels.Notification;
using Newtonsoft.Json;

namespace Frontend.Services.NotificationServices;

public class AuditNotificationService(HttpClient httpClient) : IAuditNotificationService
{
    public async Task<BaseDTOResponse<BaseNotificationViewModel>> GetNotificationsByInstitutionIdAsync(
        Guid institutionId)
    {
        var response =
            await httpClient.GetAsync(
                $"{IAuditNotificationService.ApiPath}/get-notifications-by-institution-id/{institutionId}");


        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseNotificationViewModel>>(content);

            if (result is { DtoResponses: not null, Success: true }) return result;

            return new BaseDTOResponse<BaseNotificationViewModel>
            {
                Success = false,
                Message = "An error occurred while fetching notifications"
            };
        }

        return new BaseDTOResponse<BaseNotificationViewModel>
        {
            Success = false,
            Message = "An error occurred while fetching notifications"
        };
    }

    public async Task<BaseDTOResponse<BaseNotificationViewModel>> CreateNotificationAsync(
        CreateNotificationDto notification)
    {
        var response =
            await httpClient.PostAsJsonAsync($"{IAuditNotificationService.ApiPath}/create-notification", notification);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseNotificationViewModel>>(content);

            if (result is { DtoResponse: not null, Success: true }) return result;

            return new BaseDTOResponse<BaseNotificationViewModel>
            {
                Success = false,
                Message = "An error occurred while creating notification"
            };
        }

        return new BaseDTOResponse<BaseNotificationViewModel>
        {
            Success = false,
            Message = "An error occurred while creating notification"
        };
    }

    public async Task<BaseResponse> SetNotificationReadAsync(Guid notificationId)
    {
        var response =
            await httpClient.PostAsJsonAsync(
                $"{IAuditNotificationService.ApiPath}/set-notification-read/{notificationId}",
                notificationId);

        if (response.IsSuccessStatusCode)
            return new BaseResponse("Notification updated successfully", true);

        return new BaseResponse("Failed to update notification", false);
    }
}