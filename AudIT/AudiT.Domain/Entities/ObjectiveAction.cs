using System.Text.Json.Serialization;
using AudIT.Domain.Misc;

namespace AudiT.Domain.Entities;

/// <summary>
/// This class models the action in a specific objective of an audit mission
/// </summary>
public class ObjectiveAction
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public List<ActionRisk> ActionRisks { get; private set; } = [];

    public List<String> ControaleInterneExistente { get; private set; } = [];

    public List<String> ControaleInterneAsteptate { get; private set; } = [];

    public bool Selected { get; private set; } = true;

    public Objective Objective { get; private set; }

    public Guid ObjectiveId { get; private set; }

    public ObjectiveAction()
    {
    }

    private ObjectiveAction(string name, bool selected, Objective objective)
    {
        Id = Guid.NewGuid();
        Name = name;
        Selected = selected;
        Objective = objective;
    }

    public static Result<ObjectiveAction> Create(string name, bool selected, Objective objective)
    {
        return string.IsNullOrEmpty(name)
            ? Result<ObjectiveAction>.Failure("Name is required")
            : Result<ObjectiveAction>.Success(new ObjectiveAction(name, selected, objective));
    }

    public bool AddRisk(ActionRisk actionRisk)
    {
        if (ActionRisks.Contains(actionRisk))
            return false;
        ActionRisks.Add(actionRisk);
        return true;
    }
}

public class ActionRisk
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Risk Risk { get; private set; }

    public Guid ObjectiveActionId { get; private set; }

    [JsonConstructor]
    private ActionRisk(string name, Risk risk, Guid objectiveActionId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Risk = risk;
        ObjectiveActionId = objectiveActionId;
    }


    public static Result<ActionRisk> Create(string name, Risk risk, Guid objectiveActionId)
    {
        return Result<ActionRisk>.Success(new ActionRisk(name: name, risk: risk, objectiveActionId: objectiveActionId));
    }
}

public enum Risk
{
    Mic,
    Mediu,
    Mare
}