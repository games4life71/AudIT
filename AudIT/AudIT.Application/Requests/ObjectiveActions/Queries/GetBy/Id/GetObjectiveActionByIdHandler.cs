using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.ObjectiveActions.DTO;
using AudIT.Applicationa.Requests.ObjectiveActions.Queries.GetBy.ObjectiveId;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActions.Queries.GetBy.Id;

public class GetObjectiveActionByIdHandler(
    IObjectiveActionRepository objectiveActionRepository,
    IMapper mapper
) : IRequestHandler<GetObjectiveActionByIdQuery, BaseDTOResponse<ObjActionWithRisksDto>>
{
    public async Task<BaseDTOResponse<ObjActionWithRisksDto>> Handle(GetObjectiveActionByIdQuery request,
        CancellationToken cancellationToken)
    {

        var objectiveAction = await objectiveActionRepository.FindByIdAsyncWithActionRisks(request.Id);

        if (!objectiveAction.IsSuccess)
        {
            return new BaseDTOResponse<ObjActionWithRisksDto>("Objective Activity not found", false);
        }

        var objectiveActionDto = mapper.Map<ObjActionWithRisksDto>(objectiveAction.Value);

        return new BaseDTOResponse<ObjActionWithRisksDto>(objectiveActionDto);

    }
}