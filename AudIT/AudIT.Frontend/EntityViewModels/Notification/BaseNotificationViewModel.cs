using Frontend.EntityDtos.Institution;
using Frontend.EntityDtos.Notification;
using Frontend.EntityViewModels.Recommendation;

namespace Frontend.EntityViewModels.Notification;

public class BaseNotificationViewModel
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string? AdditionalInfo { get; set; }

    public BaseRecommendationViewModel Recommendation { get; set; }

    public BaseInstitutionDto Institution { get; set; }

    public DateTime LastModifiedDate { get; set; }

    public NotificationType NotificationType { get; set; }
    public bool? IsRead { get; set; } = false;

    public bool? IsDeleted { get; set; } = false;
}