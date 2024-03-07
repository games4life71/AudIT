using AudIT.Applicationa.Requests.ObjectiveActions.DTO;
using AudIT.Applicationa.Responses;
using AudiT.Domain.Entities;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActions.Update.UpdateActionRisk;

public class UpdateActionRiskCommand:IRequest<BaseDTOResponse<ActionRiskDto>>
{
    public Guid ActionRiskId { get; set; }

    public string Name { get; private set; }

    public Risk Risk { get; private set; }

    public int Probability { get; private set; }

    public int Impact { get; private set; }

    public UpdateActionRiskCommand(Guid actionRiskId, string name, Risk risk, int probability, int impact)
    {
        ActionRiskId = actionRiskId;
        Name = name;
        Risk = risk;
        Probability = probability;
        Impact = impact;
    }
}