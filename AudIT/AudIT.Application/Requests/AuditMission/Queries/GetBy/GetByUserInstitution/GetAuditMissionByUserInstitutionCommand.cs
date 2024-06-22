using AudIT.Applicationa.Requests.AuditMission.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.AuditMission.Queries.GetBy.GetByUserInstitution;

public class GetAuditMissionByUserInstitutionCommand:IRequest<BaseDTOResponse<AuditMissionWithDateDto>>
{
    public string UserId { get; set; }

    public GetAuditMissionByUserInstitutionCommand(string userId)
    {
        UserId = userId;
    }
}