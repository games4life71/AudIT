using Frontend.EntityViewModels.ActionRisk;

namespace Frontend.EntityViewModels.ObjectiveAction;

public class ObjActionWithRisksViewModel
{
    public Guid Id { get;  set; }

    public string Name { get;  set; }

    public List<ActionRiskViewModel> ActionRisks { get;  set; }

}