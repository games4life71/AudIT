using AudIT.Applicationa.Requests.Objective.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Objective.Commands.Create;

public class CreateObjectiveCommand : IRequest<BaseDTOResponse<BaseObjectiveDto>>
{
    public string Name { get; set; }

    public Guid AuditMissionId { get; set; }

    public CreateObjectiveCommand(string name, Guid auditMissionId)
    {
        Name = name;
        AuditMissionId = auditMissionId;
    }
}