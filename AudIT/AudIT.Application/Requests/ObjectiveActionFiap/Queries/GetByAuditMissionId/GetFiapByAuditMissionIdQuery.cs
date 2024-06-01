using AudIT.Applicationa.Requests.ObjectiveActionFiap.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActionFiap.Queries.GetByAuditMissionId;

public class GetFiapByAuditMissionIdQuery:IRequest<BaseDTOResponse<BaseObjActionFiapDto>>
{

    public Guid AuditMissionId { get; set; }

    public bool MostRecent { get; set; }

    public GetFiapByAuditMissionIdQuery(Guid auditMissionId, bool mostRecent  = false)
    {
        AuditMissionId = auditMissionId;
        MostRecent = mostRecent;
    }

}