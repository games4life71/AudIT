using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Objective.DTO;
using AudIT.Applicationa.Requests.Objectives.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Objectives.Commands.Patch.RemoveObjectiveAction;

public class RemoveObjActionHandler(
    IObjectiveRepository objectiveRepository,
    IObjectiveActionRepository objectiveActionRepository,
    IMapper mapper
) : IRequestHandler<RemoveObjActionCommand, BaseDTOResponse<ObjectiveCompleteDto>>
{
    public async Task<BaseDTOResponse<ObjectiveCompleteDto>> Handle(RemoveObjActionCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var objective = await objectiveRepository.FindByIdAsync(request.ObjectiveId);


            if (!objective.IsSuccess)
            {
                return new BaseDTOResponse<ObjectiveCompleteDto>
                {
                    Message = $"Failed to find objective with id {request.ObjectiveActionId}",
                    Success = false
                };
            }


            // Check if the objective action exists

            var objectiveAction = await objectiveActionRepository.FindByIdAsync(request.ObjectiveActionId);

            if (!objectiveAction.IsSuccess)
            {
                return new BaseDTOResponse<ObjectiveCompleteDto>
                {
                    Message = $"Failed to find objective action with id {request.ObjectiveActionId}",
                    Success = false
                };
            }

            // Remove the objective action from the objective
            //

            // Update the objective
            objective.Value.RemoveObjectiveAction(objectiveAction.Value);
            var updatedObjective = await objectiveRepository.UpdateAsync(objective.Value);
            var removedObjectiveAction = await objectiveActionRepository.RemoveAsync(objectiveAction.Value);
            if (!updatedObjective.IsSuccess)
            {
                return new BaseDTOResponse<ObjectiveCompleteDto>
                {
                    Message = $"Failed to update objective action with id {request.ObjectiveActionId}",
                    Success = false
                };
            }


            return new BaseDTOResponse<ObjectiveCompleteDto>
            {
                Success = true,
                DtoResponse = mapper.Map<ObjectiveCompleteDto>(updatedObjective.Value),
                Message = $"Successfully removed objective action with id {request.ObjectiveActionId}"
            };
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<ObjectiveCompleteDto>
            {
                Message = $"An error occured : {e.Message}",
                Success = false
            };
        }
    }
}