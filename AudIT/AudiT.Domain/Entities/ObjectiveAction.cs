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


    public ObjectiveAction()
    {

    }

    private  ObjectiveAction(string name, bool selected)
    {
        Id = Guid.NewGuid();
        Name = name;
        Selected = selected;
    }

    public static Result<ObjectiveAction> Create(string name, bool selected)
    {
        return string.IsNullOrEmpty(name) ? Result<ObjectiveAction>.Failure("Name is required") : Result<ObjectiveAction>.Success(new ObjectiveAction(name, selected));
    }
}

public class ActionRisk
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Risk Risk { get; private set; }

    public ActionRisk()
    {

    }

    private  ActionRisk(string name, Risk risk)
    {
        Id = Guid.NewGuid();
        Name = name;
        Risk = risk;
    }


    public static Result<ActionRisk> Create(string name, Risk risk)
    {
        return string.IsNullOrEmpty(name) ? Result<ActionRisk>.Failure("Name is required") : Result<ActionRisk>.Success(new ActionRisk(name, risk));
    }

}

public enum Risk
{
    Mic,
    Mediu,
    Mare
}