using AudIT.Applicationa.Requests.AuditMission.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.AuditMission.Queries.GetById;

public class GetByIdQuery : IRequest<BaseDTOResponse<BaseAuditMissionDto>>
{
    public Guid Id { get; set; }

    public GetByIdQuery(Guid id)
    {
        Id = id;
    }
}