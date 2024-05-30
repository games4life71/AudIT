namespace Frontend.EntityDtos.AuditMission;

public class CreateAuditMissionDto
{
    public string name { get; set; }

    public Guid userId { get; set; }

    public Guid departmentId { get; set; }
}