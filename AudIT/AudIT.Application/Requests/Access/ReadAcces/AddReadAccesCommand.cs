using MediatR;


namespace AudIT.Applicationa.Requests.Access.ReadAcces;

public class AddReadAccesCommand : IRequest<(bool, string)>
{
    public EntityAccesType EntityAccesType { get; set; }
    public Guid UserId { get; set; }

    public Guid EntityId { get; set; }
}

public enum EntityAccesType
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