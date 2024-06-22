using AudIT.Applicationa.Requests.Recommendations.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Recommendations.Queries.GetByUserInstitution;

public class GetRecommendationsByUserInstitution:IRequest<BaseDTOResponse<BaseRecommendationDTO>>
{
    public Guid UserId { get; set; }

    public GetRecommendationsByUserInstitution(Guid userId)
    {
        UserId = userId;
    }
}