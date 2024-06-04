using Amazon.Runtime.Internal;
using AudIT.Applicationa.Requests.AuditMission.Commands.SetCurrentUserAuditMission.Dto;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.AuditMission.GetCurrentUserAuditMission;

public class GetCurrentUserAuditMissionQuery:IRequest<BaseDTOResponse<BaseCurrentUserAuditMissionDto>>
{
    public string UserId { get; set; }

    public GetCurrentUserAuditMissionQuery(string userId)
    {
        UserId = userId;
    }
}