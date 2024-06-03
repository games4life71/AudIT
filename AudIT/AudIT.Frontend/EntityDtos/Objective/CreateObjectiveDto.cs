namespace Frontend.EntityDtos.Objective;

public class CreateObjectiveDto(string name, Guid auditMissionId)
{
    public string Name { get; set; } = name;

    public Guid auditMissionId { get; set; } = auditMissionId;

}