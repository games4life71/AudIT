using AudIT.Applicationa.Requests.Recommendations.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Recommendations.Queries.GetAllByAuditMission;

public class GetRecommendationsByAuditMissionCommand : IRequest<BaseDTOResponse<BaseRecommendationDTO>>
{
    public Guid AuditMissionId { get; set; }

    public GetRecommendationsByAuditMissionCommand(Guid auditMissionId)
    {
        AuditMissionId = auditMissionId;
    }
}