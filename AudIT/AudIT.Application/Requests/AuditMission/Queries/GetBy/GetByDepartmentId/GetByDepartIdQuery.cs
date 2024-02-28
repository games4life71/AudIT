using AudIT.Applicationa.Requests.AuditMission.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.AuditMission.Queries.GetBy.GetByDepartmentId;

public class GetByDepartIdQuery:IRequest<BaseDTOResponse<BaseAuditMissionDto>>
{
    public Guid DepartmentId { get; set; }


    public GetByDepartIdQuery(Guid departmentId)
    {
        DepartmentId = departmentId;
    }
}