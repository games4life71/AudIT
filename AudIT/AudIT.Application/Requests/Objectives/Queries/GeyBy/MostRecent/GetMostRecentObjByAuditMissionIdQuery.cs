using AudIT.Applicationa.Requests.Objective.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Objectives.Queries.GeyBy.MostRecent;

public class GetMostRecentObjByAuditMissionIdQuery: IRequest<BaseDTOResponse<BaseObjectiveDto>>
{
    public Guid AuditMissionId { get; set; }
}
