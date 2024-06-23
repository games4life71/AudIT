using AudIT.Domain.Misc;

namespace AudiT.Domain.Entities;

public class Notification : AuditableEntity
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string? AdditionalInfo { get; set; }

    public Guid RecommendationId { get; set; }

    public Recommendation Recommendation { get; set; }

    public Guid InstitutionId { get; set; }

    public Institution Institution { get; set; }

    public bool? IsRead { get; set; } = false;

    public bool? IsDeleted { get; set; } = false;

    private Notification(string title, string? additionalInfo, Guid recommendationId, Guid institutionId)
    {
        Title = title;
        AdditionalInfo = additionalInfo;
        RecommendationId = recommendationId;
        InstitutionId = institutionId;
    }

    public static Result<Notification> Create(string title, string? additionalInfo, Guid recommendationId,
        Guid institutionId)
    {
        var notification = new Notification(title, additionalInfo, recommendationId, institutionId);
        return Result<Notification>.Success(notification);
    }

}