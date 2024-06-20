using AudIT.Applicationa.Requests.Recommendations.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Recommendations.Queries.GetAllRecentsByUser;

public class GetRecentRecommendationsByUserQuery : IRequest<BaseDTOResponse<BaseRecommendationDTO>>
{
    public Guid UserId { get; set; }

    public GetRecentRecommendationsByUserQuery(Guid userId)
    {
        UserId = userId;
    }
}