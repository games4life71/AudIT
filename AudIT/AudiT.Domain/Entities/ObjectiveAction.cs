using System.Text.Json.Serialization;
using AudIT.Domain.Misc;

namespace AudiT.Domain.Entities;

/// <summary>
/// This class models the action in a specific objective of an audit mission
/// </summary>
public class ObjectiveAction:AuditableEntity
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public List<ActionRisk> ActionRisks { get; private set; } = [];

    public List<String> ControaleInterneExistente { get; private set; } = [];

    public List<String> ControaleInterneAsteptate { get; private set; } = [];

    public bool Selected { get; private set; } = true;

    [JsonIgnore] public Objective Objective { get; private set; }

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

    public int Probability { get; private set; }

    public int Impact { get; private set; }

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

    public static Result<ActionRisk> Create(string name, Risk risk, Guid objectiveActionId, int probability, int impact)
    {
        var actionRisk = new ActionRisk(name: name, risk: risk, objectiveActionId: objectiveActionId);
        actionRisk.SetProbability(probability);
        actionRisk.SetImpact(impact);
        return Result<ActionRisk>.Success(actionRisk);
    }


    public void SetProbability(int probability)
    {
        Probability = probability;
    }

    public void SetImpact(int impact)
    {
        Impact = impact;
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public void SetRisk(Risk risk)
    {
        Risk = risk;
    }

    public void SetObjectiveActionId(Guid objectiveActionId)
    {
        ObjectiveActionId = objectiveActionId;
    }

    public void SetId(Guid id)
    {
        Id = id;
    }
}

public enum Risk
{   None,
    Mic,
    Mediu,
    Mare
}