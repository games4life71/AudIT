using AudIT.Applicationa.Requests.Activity.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Activity.Queries.GetByAuditMissionId;

public class GetActivitiesByAuditMissionIdQuery : IRequest<BaseDTOResponse<BaseActivityDto>>
{
    public Guid AuditMissionId { get; set; }

    public bool MostRecent = false;

    public GetActivitiesByAuditMissionIdQuery(Guid auditMissionId, bool mostRecent = false)
    {
        MostRecent = mostRecent;
        AuditMissionId = auditMissionId;
    }
}