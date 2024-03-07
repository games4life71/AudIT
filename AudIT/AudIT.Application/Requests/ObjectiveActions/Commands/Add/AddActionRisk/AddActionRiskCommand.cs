using AudIT.Applicationa.Requests.ObjectiveActions.DTO;
using AudIT.Applicationa.Responses;
using AudiT.Domain.Entities;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActions.Commands.Add.AddActionRisk;

public class AddActionRiskCommand : IRequest<BaseDTOResponse<ObjActionWithRisksDto>>
{
    public Guid ObjectiveActionId { get; set; }

    private ActionRisk ActionRisk { get; set; }

    public string? ActionRiskName { get; set; }

    public int Probability { get; set; }

    public int Impact { get; set; }

    public Risk Risk { get; set; }

    public AddActionRiskCommand(Guid objectiveActionId, string actionRiskName, int probability, int impact, Risk risk)
    {
        ObjectiveActionId = objectiveActionId;
        ActionRisk = ActionRisk.Create(actionRiskName, risk, objectiveActionId).Value;
        ActionRisk.SetProbability(probability);
        ActionRisk.SetImpact(impact);
    }

    public ActionRisk GetActionRisk()
    {
        return ActionRisk;
    }


}