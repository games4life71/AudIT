namespace Frontend.EntityViewModels.ActionRisk;

public class ActionRiskViewModel
{
    public string id { get; set; }

    public string name { get; set; }

    public int risk { get; set; }

    public int probability { get; set; }

    public int impact { get; set; }

    public string objectiveActionId { get; set; }

    public ActionRiskViewModel(string id, string name, int risk, int probability, int impact, string objectiveActionId)
    {
        this.id = id;
        this.name = name;
        this.risk = risk;
        this.probability = probability;
        this.impact = impact;
        this.objectiveActionId = objectiveActionId;
    }

    public ActionRiskViewModel()
    {

    }
}