using AudiT.Domain.Entities;

namespace AudIT.Applicationa.Requests.AuditMission.DTO;

public class AuditMissionWithDateDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string UserId { get; set; }

    public Guid DepartmentId { get; set; }

    public AuditMissionStatus Status { get; set; } = AuditMissionStatus.Creata;

    public DateTime LastModifiedDate { get; set; }



}