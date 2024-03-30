using AudIT.Applicationa.Requests.Activity.DTO;
using AudIT.Applicationa.Responses;
using AudiT.Domain.Entities;
using MediatR;

namespace AudIT.Applicationa.Requests.Activity.Commands.Add;

public class CreateActivityCommand:IRequest<BaseDTOResponse<BaseActivityDto>>
{
    public string Name { get; set; }

    public ActivityType Type { get; set; }

    public Guid DepartmentId { get; set; }

    public Guid AuditMissionId { get; set; }

    public Guid UserId { get; set; }

    public CreateActivityCommand(string name, ActivityType type, Guid departmentId, Guid userId,Guid auditMissionId)
    {
        Name = name;
        Type = type;
        DepartmentId = departmentId;
        UserId = userId;
        AuditMissionId = auditMissionId;
    }

}