using AudIT.Domain.Misc;

namespace AudiT.Domain.Entities;

public class CurrentUsersAuditMission
{
    public Guid Id { get; set; }

    public string UserId { get; set; }

    public Guid AuditMissionId { get; set; }

    public CurrentUsersAuditMission()
    {
    }

    private CurrentUsersAuditMission(string userId, Guid auditMissionId)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        AuditMissionId = auditMissionId;
    }

    public static Result<CurrentUsersAuditMission> Create(string userId, Guid auditMissionId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return Result<CurrentUsersAuditMission>.Failure("User Id is required");
        }

        if (auditMissionId == Guid.Empty)
        {
            return Result<CurrentUsersAuditMission>.Failure("Audit Mission Id is required");
        }

        return Result<CurrentUsersAuditMission>.Success(new CurrentUsersAuditMission(userId, auditMissionId));
    }
}