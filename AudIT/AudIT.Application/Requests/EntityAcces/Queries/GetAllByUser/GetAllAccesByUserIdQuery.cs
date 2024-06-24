using AudIT.Applicationa.Requests.EntityAcces.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.EntityAcces.Queries.GetAllByUser;


public class GetAllAccesByUserIdQuery:IRequest<BaseDTOResponse<BaseEntityAccesDto>>
{
    public Guid UserId { get; set; }

    public GetAllAccesByUserIdQuery(Guid userId)
    {
        UserId = userId;
    }
}
