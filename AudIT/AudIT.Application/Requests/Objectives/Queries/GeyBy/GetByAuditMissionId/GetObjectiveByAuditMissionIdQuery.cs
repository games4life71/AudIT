using AudIT.Applicationa.Requests.Objectives.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Objectives.Queries.GeyBy.GetByAuditMissionId;

public class GetObjectiveByAuditMissionIdQuery : IRequest<BaseDTOResponse<ObjectiveCompleteDto>>
{
    public Guid AuditMissionId { get; set; }
}