using AudIT.Applicationa.Requests.Objective.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Objectives.Queries.GeyBy.GetByRecommendationId;

public class GetObjectiveByRecommendationIdQuery : IRequest<BaseDTOResponse<BaseObjectiveDto>>
{
    public Guid RecommendationId { get; set; }

    public GetObjectiveByRecommendationIdQuery(Guid recommendationId)
    {
        RecommendationId = recommendationId;
    }

}