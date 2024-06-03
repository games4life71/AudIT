using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.ObjectiveActions.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActions.Commands.Add.AddActionRisk;

public class AddActionRiskHandler(
    IObjectiveActionRepository _objectiveActionRepository,
    IActionRiskRepository _actionRiskRepository,
    IMapper _mapper) : IRequestHandler<AddActionRiskCommand, BaseDTOResponse<ObjActionWithRisksDto>>
{
    public async Task<BaseDTOResponse<ObjActionWithRisksDto>> Handle(AddActionRiskCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var objectveAction = await _objectiveActionRepository.FindByIdAsync(request.ObjectiveActionId);
            Console.WriteLine("the name of the action risk " + request.ActionRiskName);

            if (!objectveAction.IsSuccess)
                return new BaseDTOResponse<ObjActionWithRisksDto>(
                    $"Objective Activity with id {request.ObjectiveActionId} not found ", false);

            // Add the risk to the objective action

            bool succes = objectveAction.Value.AddRisk(request.GetActionRisk());
            if (!succes)
                return new BaseDTOResponse<ObjActionWithRisksDto>(
                    $"Risk with id {request.GetActionRisk().Id} already exists in the objective action", false);

            Console.WriteLine(objectveAction.Value.ActionRisks.Count + " is the number of risks");
            var result = await _actionRiskRepository.AddAsync(request.GetActionRisk());


            if (!result.IsSuccess)
                return new BaseDTOResponse<ObjActionWithRisksDto>(
                    $"Error adding risk to objective action with id {request.ObjectiveActionId}", false);


            objectveAction = await _objectiveActionRepository.FindByIdAsyncWithActionRisks(request.ObjectiveActionId);
            var returnDto =
                new ObjActionWithRisksDto(result.Value.Id, result.Value.Name, objectveAction.Value.ActionRisks);

            return new BaseDTOResponse<ObjActionWithRisksDto>(returnDto, "succes", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<ObjActionWithRisksDto>($"Error adding risk to objective action: {e.Message}",
                false);
        }
    }
}