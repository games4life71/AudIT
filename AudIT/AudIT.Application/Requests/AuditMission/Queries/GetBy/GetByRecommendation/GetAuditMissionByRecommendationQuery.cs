using AudIT.Applicationa.Requests.AuditMission.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.AuditMission.Queries.GetBy.GetByRecommendation;

public class GetAuditMissionByRecommendationQuery:IRequest<BaseDTOResponse<BaseAuditMissionDto>>
{

    public Guid RecommendationId { get; set; }

    public GetAuditMissionByRecommendationQuery(Guid recommendationId)
    {
        RecommendationId = recommendationId;
    }
}