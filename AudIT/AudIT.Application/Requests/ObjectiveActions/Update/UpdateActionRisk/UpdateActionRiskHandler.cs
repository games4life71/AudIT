using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.ObjectiveActions.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActions.Update.UpdateActionRisk;

public class UpdateActionRiskHandler(
    IActionRiskRepository actionRiskRepository,
    IMapper mapper
) : IRequestHandler<UpdateActionRiskCommand, BaseDTOResponse<ActionRiskDto>>
{
    public async Task<BaseDTOResponse<ActionRiskDto>> Handle(UpdateActionRiskCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var actionRisk = await actionRiskRepository.FindByIdAsync(request.ActionRiskId);
            if (!actionRisk.IsSuccess)
            {
                return new BaseDTOResponse<ActionRiskDto>($"Action Risk with id {request.ActionRiskId} not found",
                    false);
            }

            actionRisk.Value.SetName(request.Name);
            actionRisk.Value.SetRisk(request.Risk);
            actionRisk.Value.SetImpact(request.Impact);
            actionRisk.Value.SetProbability(request.Probability);


            var result = await actionRiskRepository.UpdateAsync(actionRisk.Value);

            if (!result.IsSuccess)
            {
                return new BaseDTOResponse<ActionRiskDto>($"Error updating Action Risk: {result.Error}", false);
            }

            return new BaseDTOResponse<ActionRiskDto>(mapper.Map<ActionRiskDto>(result.Value),
                "Action Risk updated successfully", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<ActionRiskDto>($"Error updating Action Risk: {e.Message}", false);
        }
    }
}