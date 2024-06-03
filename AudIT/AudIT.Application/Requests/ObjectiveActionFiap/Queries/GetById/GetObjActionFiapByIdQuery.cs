using AudIT.Applicationa.Requests.ObjectiveActionFiap.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActionFiap.Commands.Queries.GetById;

public class GetObjActionFiapByIdQuery : IRequest<BaseDTOResponse<BaseObjActionFiapDto>>
{
    public Guid Id { get; set; }


    public GetObjActionFiapByIdQuery(Guid id)
    {
        Id = id;
    }
}