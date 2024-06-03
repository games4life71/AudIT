using AudIT.Applicationa.Requests.ObjectiveActions.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActions.Queries.GetBy.Id;

public class GetObjectiveActionByIdQuery:IRequest<BaseDTOResponse<ObjActionWithRisksDto>>
{
    public Guid Id { get; set; }

    public GetObjectiveActionByIdQuery(Guid id)
    {
        Id = id;
    }

}