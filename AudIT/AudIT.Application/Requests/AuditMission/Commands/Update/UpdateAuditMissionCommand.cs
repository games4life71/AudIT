using AudIT.Applicationa.Requests.AuditMission.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.AuditMission.Commands.Update;

public class UpdateAuditMissionCommand : IRequest<BaseDTOResponse<BaseAuditMissionDto>>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid DepartmentId { get; set; }


    public UpdateAuditMissionCommand(Guid id, string name,  Guid departmentId)
    {
        Id = id;
        Name = name;
        DepartmentId = departmentId;
    }
}