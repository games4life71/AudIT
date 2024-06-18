using AudIT.Applicationa.Requests.Recommendations.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Recommendations.Queries.GetAllByObjActionId;

public class GetAllRecommendationsByObjActionQuery:IRequest<BaseDTOResponse<BaseRecommendationDTO>>
{
    public Guid ObjectiveActionId { get; set; }

    public GetAllRecommendationsByObjActionQuery(Guid objectiveActionId)
    {
        ObjectiveActionId = objectiveActionId;
    }
}