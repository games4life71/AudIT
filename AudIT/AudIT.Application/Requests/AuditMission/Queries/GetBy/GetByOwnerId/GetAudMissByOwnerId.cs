using AudIT.Applicationa.Requests.AuditMission.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.AuditMission.Queries.GetBy.GetByOwnerId;

public class GetAudMissByOwnerId : IRequest<BaseDTOResponse<AuditMissionWithDateDto>>
{
    public GetAudMissByOwnerId(string id)
    {
        Id = id;
    }

    public string Id { get; set; }
}