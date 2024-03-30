using AudIT.Applicationa.Requests.Activity.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Activity.Queries;

public class GetActivityByIdQuery : IRequest<BaseDTOResponse<ActivityWIthDocumentsDto>>
{
    public Guid Id { get; set; }

    public GetActivityByIdQuery(Guid id)
    {
        Id = id;
    }
}