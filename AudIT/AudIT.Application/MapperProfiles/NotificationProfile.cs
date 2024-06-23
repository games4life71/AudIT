using AudIT.Applicationa.Requests.Notification.DTO;
using AudiT.Domain.Entities;

namespace AudIT.Applicationa.MapperProfiles;

public class NotificationProfile:MyCustomProfile
{
    public NotificationProfile()
    {
        CreateMap<Notification, BaseNotificationDto>();
        CreateMap<Notification, NotificationWithDateDto>();
    }
}