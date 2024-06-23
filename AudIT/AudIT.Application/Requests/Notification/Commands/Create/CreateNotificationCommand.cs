using AudIT.Applicationa.Requests.Notification.DTO;
using AudIT.Applicationa.Responses;
using AudiT.Domain.Entities;
using MediatR;

namespace AudIT.Applicationa.Requests.Notification.Commands.Create;

public class CreateNotificationCommand : IRequest<BaseDTOResponse<BaseNotificationDto>>
{
    public Guid RecommendationId { get; set; }

    public Guid InstitutionId { get; set; }

    public NotificationType NotificationType { get; set; }
    public string Title { get; set; }

    public string? AdditionalInfo { get; set; }

    public CreateNotificationCommand(Guid recommendationId, Guid institutionId, string title, string? additionalInfo, NotificationType notificationType)
    {
        RecommendationId = recommendationId;
        InstitutionId = institutionId;
        Title = title;
        AdditionalInfo = additionalInfo;
        NotificationType = notificationType;
    }

}