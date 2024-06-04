namespace AudIT.Applicationa.Requests.AuditMission.Commands.SetCurrentUserAuditMission.Dto;

public class BaseCurrentUserAuditMissionDto
{
    public Guid Id { get; set; }

    public string UserId { get; set; }

    public Guid AuditMissionId { get; set; }

}