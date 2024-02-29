namespace AudIT.Applicationa.Requests.Objective.DTO;

public class BaseObjectiveDto
{
    public Guid Id { get; set; }

    public string Name { get; private set; }

    public Guid AuditMissionId { get; private set; }

    public BaseObjectiveDto(Guid id, string name, Guid auditMissionId)
    {
        Id = id;
        Name = name;
        AuditMissionId = auditMissionId;
    }
}