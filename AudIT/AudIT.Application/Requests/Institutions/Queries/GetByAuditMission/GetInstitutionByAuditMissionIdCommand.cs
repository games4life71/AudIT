using AudIT.Applicationa.Requests.Institution.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Institutions.Queries.GetByDepartment;

public class GetInstitutionByAuditMissionIdCommand : IRequest<BaseDTOResponse<BaseInstitutionDto>>
{
    public Guid AuditMissionId { get; set; }

    public GetInstitutionByAuditMissionIdCommand(Guid auditMissionId)
    {
        AuditMissionId = auditMissionId;
    }
}