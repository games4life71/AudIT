using AudIT.Applicationa.Requests.Objective.DTO;
using AudIT.Applicationa.Requests.Objectives.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Objectives.Queries.GeyBy.GetByAuditMissionId;

public class GetObjectiveByAuditMissionIdQuery : IRequest<BaseDTOResponse<BaseObjectiveDto>>
{
    public Guid AuditMissionId { get; set; }
}