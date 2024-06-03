using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.ObjectiveActions.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActions.Queries.GetAllSelected;

public class GetAllObjActionsHandler(
    IObjectiveActionRepository _objectiveActionRepository,
    IMapper _mapper
) : IRequestHandler<GetAllObjActionsCommand, BaseDTOResponse<ObjActionWithRisksDto>>
{
    public async Task<BaseDTOResponse<ObjActionWithRisksDto>> Handle(GetAllObjActionsCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _objectiveActionRepository.GetAllSelectedByObjectiveId(request.ObjectiveId);

        if (!result.IsSuccess)
        {
            return new BaseDTOResponse<ObjActionWithRisksDto>(result.Error, false);
        }

        var objActions = _mapper.Map<List<ObjActionWithRisksDto>>(result.Value);

        return new BaseDTOResponse<ObjActionWithRisksDto>(objActions, "Objective Actions retrieved successfully", true);
    }
}