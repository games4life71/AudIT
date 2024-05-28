using AudiT.Domain.Entities;

namespace AudIT.Applicationa.Requests.AuditMission.DTO;

public class BaseAuditMissionDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string UserId { get; set; }

    public Guid DepartmentId { get; set; }

    public AuditMissionStatus Status { get; set; } = AuditMissionStatus.Creata;

    public BaseAuditMissionDto(Guid id, string name, string userId, Guid departmentId)
    {
        Id = id;
        Name = name;
        UserId = userId;
        DepartmentId = departmentId;
    }


}