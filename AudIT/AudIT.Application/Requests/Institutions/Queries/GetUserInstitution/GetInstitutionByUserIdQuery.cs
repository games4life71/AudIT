using AudIT.Applicationa.Requests.Institution.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Institutions.Queries.GetUserInstitution;

public class GetInstitutionByUserIdQuery:IRequest<BaseDTOResponse<BaseInstitutionDto>>
{
    public Guid UserId { get; set; }

    public GetInstitutionByUserIdQuery(Guid userId)
    {
        UserId = userId;
    }
}