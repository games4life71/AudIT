using AudIT.Applicationa.Requests.ObjectiveActionFiap.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActionFiap.Queries.GetByObjectiveActionId;

public class GetFiapByObjActionIdQuery : IRequest<BaseDTOResponse<BaseObjActionFiapDto>>
{
    public Guid ObjectiveActionId { get; set; }

    public GetFiapByObjActionIdQuery(Guid objectiveActionId)
    {
        ObjectiveActionId = objectiveActionId;
    }
}