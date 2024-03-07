using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.ObjectiveActions.DTO;
using AudIT.Applicationa.Responses;
using AudiT.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActions.Commands.Create;

public class CreateBaseObjActionHandler(
    IObjectiveActionRepository objectiveActionRepository,
    IMapper mapper,
    IObjectiveRepository objectiveRepository
) : IRequestHandler<CreateBaseObjActionCommand, BaseDTOResponse<BaseObjActionDto>>
{
    public async Task<BaseDTOResponse<BaseObjActionDto>> Handle(CreateBaseObjActionCommand request,
        CancellationToken cancellationToken)
    {
        //get the objective

        try
        {
            var objective = await objectiveRepository.FindByIdAsync(request.ObjectiveId);

            if (!objective.IsSuccess)
                return new BaseDTOResponse<BaseObjActionDto>($"Objective with id {request.ObjectiveId} not found",
                    false);


            var objectiveAction = ObjectiveAction.Create(
                request.Name,
                true,
                objective.Value
            );

            if (!objectiveAction.IsSuccess)
                return new BaseDTOResponse<BaseObjActionDto>("Cannot create new obj action" + objectiveAction.Error,
                    false);

            var result = await objectiveActionRepository.AddAsync(objectiveAction.Value);

            if (!result.IsSuccess)
                return new BaseDTOResponse<BaseObjActionDto>("Cannot create new obj action" + result.Error, false);

            return new BaseDTOResponse<BaseObjActionDto>(mapper.Map<BaseObjActionDto>(result.Value));
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseObjActionDto>("Cannot create new obj action" + e.Message, false);
        }
    }
}