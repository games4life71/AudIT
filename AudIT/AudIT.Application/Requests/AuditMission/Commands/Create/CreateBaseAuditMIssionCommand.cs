using AudIT.Applicationa.Requests.AuditMission.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.AuditMission.Commands.Create;

public class CreateBaseAuditMIssionCommand : IRequest<BaseDTOResponse<BaseAuditMissionDto>>
{
    public string Name { get; set; }

    public string UserId { get; set; }

    public Guid DepartmentId { get; set; }

    public CreateBaseAuditMIssionCommand(string name, string userId, Guid departmentId)
    {
        Name = name;
        UserId = userId;
        DepartmentId = departmentId;
    }
}