using MediatR;


namespace AudIT.Applicationa.Requests.Access.ReadAcces;

public class AddReadAccesCommand : IRequest<(bool, string)>
{
    public EntityType EntityType { get; set; }
    public Guid UserId { get; set; }

    public Guid EntityId { get; set; }
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