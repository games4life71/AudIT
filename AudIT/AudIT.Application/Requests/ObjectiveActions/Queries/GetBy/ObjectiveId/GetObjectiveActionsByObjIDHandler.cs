using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.ObjectiveActions.DTO;
using AudIT.Applicationa.Responses;
using AudiT.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActions.Queries.GetBy.ObjectiveId;

public class GetObjectiveActionsByObjIDHandler(
    IObjectiveActionRepository objectiveActionRepository,
    IMapper mapper) : IRequestHandler<GetObjectiveActionsByObjID, BaseDTOResponse<ObjActionWithRisksDto>>
{
    public async Task<BaseDTOResponse<ObjActionWithRisksDto>> Handle(GetObjectiveActionsByObjID request,
        CancellationToken cancellationToken)
    {
        //get the objective actions by objective id
        try
        {
            var objectiveActions = await objectiveActionRepository.FindAllByObjectiveIdAsync(request.ObjectiveId);

            if (!objectiveActions.IsSuccess)
            {
                return new BaseDTOResponse<ObjActionWithRisksDto>(
                    "No objective actions found for the given objective id",
                    false);
            }

            var mappedObjActions = mapper.Map<List<ObjActionWithRisksDto>>(objectiveActions.Value);
            // var mappedObjActions = objectiveActions.Value.Select(x => new ObjActionWithRisksDto
            //     (x.Id, x.Name, null)
            // ).ToList();
            return new BaseDTOResponse<ObjActionWithRisksDto>(mappedObjActions, "Succes", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<ObjActionWithRisksDto>(e.Message, false);
        }
    }
}