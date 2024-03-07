using AudIT.Applicationa.Requests.Objectives.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Objectives.Queries.GeyBy.Id;

public class GetObjByIdQuery : IRequest<BaseDTOResponse<ObjectiveCompleteDto>>
{
    public Guid Id { get; set; }

    public GetObjByIdQuery(Guid id)
    {
        Id = id;
    }
}