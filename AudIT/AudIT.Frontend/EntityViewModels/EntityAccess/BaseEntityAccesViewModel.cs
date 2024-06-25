namespace Frontend.EntityViewModels.EntityAccess;

public class BaseEntityAccesViewModel
{
    public Guid Id { get; set; }

    public string UserId { get; set; }

    public string GrantedByUserId { get; set; }

    public Guid EntityId { get; set; }

    public EntityType Type { get; set; }

    public AccesType AccesType { get; set; }
}


public enum EntityType
{
    Activity,
    AuditMission,
    Department,
    Institution,
    Objective,
    ObjectiveAction,
    ObjectiveActionFiap,
    Recommendation,
    StandaloneDocument,
    TemplateDocument
}

public enum AccesType
{
    Read,
    Write
}