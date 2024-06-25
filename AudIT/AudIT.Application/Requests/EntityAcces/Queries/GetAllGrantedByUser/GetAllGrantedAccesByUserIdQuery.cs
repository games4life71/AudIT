using AudIT.Applicationa.Requests.EntityAcces.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.EntityAcces.Queries.GetAllGrantedByUser;

public class GetAllGrantedAccesByUserIdQuery : IRequest<BaseDTOResponse<EntityAccesWithUserInfo>>
{
    public Guid UserId { get; set; }

    public GetAllGrantedAccesByUserIdQuery(Guid userId)
    {
        UserId = userId;
    }
}