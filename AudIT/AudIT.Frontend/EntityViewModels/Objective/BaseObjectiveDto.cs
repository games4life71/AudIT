namespace Frontend.EntityViewModels.Objective;

public class BaseObjectiveViewModel
{
    public Guid Id { get; set; }

    public string Name { get; private set; }

    public Guid AuditMissionId { get; private set; }

    public BaseObjectiveViewModel(Guid id, string name, Guid auditMissionId)
    {
        Id = id;
        Name = name;
        AuditMissionId = auditMissionId;
    }
}