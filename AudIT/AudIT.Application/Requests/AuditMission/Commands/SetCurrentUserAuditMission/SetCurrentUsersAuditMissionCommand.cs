using AudIT.Applicationa.Requests.AuditMission.Commands.SetCurrentUserAuditMission.Dto;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.AuditMission.Commands.SetCurrentUserAuditMission;

public class SetCurrentUsersAuditMissionCommand:IRequest<BaseDTOResponse<BaseCurrentUserAuditMissionDto>>
{
    public string UserId { get; set; }

    public Guid AuditMissionId { get; set; }

}