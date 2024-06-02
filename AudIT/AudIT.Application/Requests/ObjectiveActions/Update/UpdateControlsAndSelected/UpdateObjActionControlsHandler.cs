using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.ObjectiveActions.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActions.Update.UpdateControlsAndSelected;

public class UpdateObjActionControlsHandler(
    IObjectiveActionRepository objectiveActionRepository,
    IMapper mapper
) : IRequestHandler<UpdateObjActionControlsCommand, BaseDTOResponse<BaseObjActionDto>>
{
    public async Task<BaseDTOResponse<BaseObjActionDto>> Handle(UpdateObjActionControlsCommand request,
        CancellationToken cancellationToken)
    {
        var existingObjAction = await objectiveActionRepository.FindByIdAsync(request.Id);

        if (!existingObjAction.IsSuccess)
        {
            return new BaseDTOResponse<BaseObjActionDto>
            {
                Success = false,
                Message = $"Cannot find Objective Action with id {request.Id}"
            };
        }

        var objAction = existingObjAction.Value;

        objAction.SetSelected(request.Selected);
        foreach (var control in request.ControaleInterneAsteptate)
        {
            objAction.AddControaleInterneAsteptate(control);
        }

        foreach (var control in request.ControaleInterneExistente)
        {
            objAction.AddControaleInterneExistente(control);
        }

        var result = await objectiveActionRepository.UpdateAsync(objAction);

        if (!result.IsSuccess)
        {
            return new BaseDTOResponse<BaseObjActionDto>
            {
                Success = false,
                Message = $"Failed to update Objective Action with id {request.Id}"
            };
        }

        return new BaseDTOResponse<BaseObjActionDto>(mapper.Map<BaseObjActionDto>(result.Value));
    }
}