using AudIT.Applicationa.Requests.ObjectiveActions.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActions.Queries.GetBy.ObjectiveId;

public class GetObjectiveActionsByObjID : IRequest<BaseDTOResponse<ObjActionWithRisksDto>>
{
    public Guid ObjectiveId { get; set; }

    public GetObjectiveActionsByObjID(Guid objectiveId)
    {
        ObjectiveId = objectiveId;
    }
}