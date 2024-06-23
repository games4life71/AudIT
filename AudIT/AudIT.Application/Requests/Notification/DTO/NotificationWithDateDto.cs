using AudIT.Applicationa.Requests.Institution.DTO;
using AudIT.Applicationa.Requests.Recommendations.DTO;
using AudiT.Domain.Entities;

namespace AudIT.Applicationa.Requests.Notification.DTO;

public class NotificationWithDateDto
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string? AdditionalInfo { get; set; }

    public BaseRecommendationDTO Recommendation { get; set; }

    public BaseInstitutionDto Institution { get; set; }

    public NotificationType NotificationType { get; set; }

    public bool? IsRead { get; set; } = false;

    public bool? IsDeleted { get; set; } = false;

    public DateTime LastModifiedDate { get; set; }
}