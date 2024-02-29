using AudIT.Applicationa.Requests.ObjectiveActions.DTO;
using AudIT.Applicationa.Responses;
using AudiT.Domain.Entities;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActions.Commands.Add.AddActionRisk;

public class AddActionRiskCommand : IRequest<BaseDTOResponse<ObjActionWithRisksDto>>
{
    public Guid ObjectiveActionId { get; set; }

    public ActionRisk ActionRisk { get; set; }

    public AddActionRiskCommand(Guid objectiveActionId, ActionRisk actionRisk)
    {
        ObjectiveActionId = objectiveActionId;
        ActionRisk = actionRisk;
    }
}