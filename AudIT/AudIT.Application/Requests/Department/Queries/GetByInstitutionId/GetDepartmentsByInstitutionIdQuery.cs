using AudIT.Applicationa.Requests.Department.Dto;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Department.Queries.GetByInstitutionId;

public class GetDepartmentsByInstitutionIdQuery : IRequest<BaseDTOResponse<BaseDepartmentDto>>
{
    public Guid InstitutionId { get; set; }
}