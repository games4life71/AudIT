using AudIT.Domain.Misc;

namespace AudiT.Domain.Entities;

/// <summary>
/// Class that models the  main objectives of an audit mission
/// Each objective contains multiple actions(different from the action in an audit mission) that need to be computed
/// </summary>
public class Objective:AuditableEntity
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public AuditMission AuditMission { get; private set; }

    public Guid AuditMissionId { get; private set; }

    public List<ObjectiveAction> ObjectiveActions { get; private set; } = [];




    private Objective(string name, Guid auditMissionId)
    {
        Id = new Guid();
        Name = name;
        // AuditMission = auditMission;
        AuditMissionId = auditMissionId;
    }


    public static Result<Objective> Create(string name, Guid auditMissionId)
    {
        //TODO : Add validation logic here
        return Result<Objective>.Success(new Objective(name, auditMissionId));
    }


    public void AddObjectiveAction(ObjectiveAction objectiveAction)
    {
        ObjectiveActions.Add(objectiveAction);
    }
}