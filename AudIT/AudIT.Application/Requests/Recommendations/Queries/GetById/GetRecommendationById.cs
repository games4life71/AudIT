using AudIT.Applicationa.Requests.Recommendations.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Recommendations.Queries.GetById;

public class GetRecommendationById : IRequest<BaseDTOResponse<BaseRecommendationDTO>>
{
    public Guid Id { get; set; }

    public GetRecommendationById(Guid id)
    {
        Id = id;
    }
}