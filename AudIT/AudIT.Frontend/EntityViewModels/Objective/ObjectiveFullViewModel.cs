using Frontend.EntityViewModels.ObjectiveAction;

namespace Frontend.EntityViewModels.Objective;

public class ObjectiveFullViewModel
{
    public List<ObjectiveActionViewModel> objectiveActions { get; set; }

    public string id { get; set; }

    public string name { get; set; }

    public string auditMissionId { get; set; }

}