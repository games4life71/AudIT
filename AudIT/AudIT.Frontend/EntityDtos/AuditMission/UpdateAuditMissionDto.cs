namespace Frontend.EntityDtos.AuditMission;

public class UpdateAuditMissionDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public Guid DepartmentId { get; set; }

    public AuditMissionStatus Status { get; set; }

}