using Frontend.EntityDtos.Misc;
using Frontend.EntityDtos.Notification;
using Frontend.EntityViewModels.Notification;

namespace Frontend.Contracts.Abstract_Services.Notification;

public interface IAuditNotificationService
{
    public const string ApiPath = "https://localhost:7248/api/Notification";

    public Task<BaseDTOResponse<BaseNotificationViewModel>> GetNotificationsByInstitutionIdAsync(Guid institutionId);

    public Task<BaseDTOResponse<BaseNotificationViewModel>> CreateNotificationAsync(CreateNotificationDto notification);

}