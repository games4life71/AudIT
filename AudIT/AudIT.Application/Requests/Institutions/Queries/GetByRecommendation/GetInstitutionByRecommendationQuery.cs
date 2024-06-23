using AudIT.Applicationa.Requests.Institution.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Institutions.Queries.GetByRecommendation;

public class GetInstitutionByRecommendationQuery:IRequest<BaseDTOResponse<BaseInstitutionDto>>
{
    public Guid RecommendationId { get; set; }

    public GetInstitutionByRecommendationQuery(Guid recommendationId)
    {
        RecommendationId = recommendationId;
    }
}