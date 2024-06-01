using Frontend.EntityViewModels.ActionRisk;

namespace Frontend.EntityViewModels.ObjectiveAction;

public class ObjectiveActionViewModel
{
    public string id { get; set; }

    public string name { get; set; }

    public List<ActionRiskViewModel> actionRisks { get; set; }

    public List<object> controaleInterneExistente { get; set; }

    public List<object> controaleInterneAsteptate { get; set; }

    public bool selected { get; set; }

    public string objectiveId { get; set; }

    public object createdBy { get; set; }

    public DateTime createdDate { get; set; }

    public object lastModifiedBy { get; set; }

    public DateTime lastModifiedDate { get; set; }

    public List<object> writeAccesUserId { get; set; }

    public List<object> readAccesUserId { get; set; }
}