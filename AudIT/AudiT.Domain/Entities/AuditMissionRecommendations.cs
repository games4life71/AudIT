using AudIT.Domain.Misc;

namespace AudiT.Domain.Entities;

/// <summary>
/// This class models  the recommendations of an audit mission
/// </summary>
public class AuditMissionRecommendations
{
    public Guid Id { get; private set; }

    public AuditMission AuditMission { get; private set; }

    public Guid AuditMissionId { get; private set; }

    public Recommendation Recommendation { get; private set; }

    public Guid RecommendationId { get; private set; }


    public AuditMissionRecommendations()
    {

    }
    private AuditMissionRecommendations(AuditMission auditMission, Guid auditMissionId, Recommendation recommendation,
        Guid recommendationId)
    {
        AuditMission = auditMission;
        AuditMissionId = auditMissionId;
        Recommendation = recommendation;
        RecommendationId = recommendationId;
    }


    public static Result<AuditMissionRecommendations> Create(AuditMission auditMission, Recommendation recommendation)
    {
        //TODO : Add validation logic here
        return Result<AuditMissionRecommendations>.Success(
            new AuditMissionRecommendations(auditMission, auditMission.Id, recommendation, recommendation.Id));
    }
}