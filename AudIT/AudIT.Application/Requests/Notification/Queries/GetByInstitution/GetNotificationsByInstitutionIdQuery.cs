using AudIT.Applicationa.Requests.Notification.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Notification.Queries.GetByInstitution;

public class GetNotificationsByInstitutionIdQuery : IRequest<BaseDTOResponse<BaseNotificationDto>>
{
    public Guid InstitutionId { get; set; }

    public GetNotificationsByInstitutionIdQuery(Guid institutionId)
    {
        InstitutionId = institutionId;
    }
}