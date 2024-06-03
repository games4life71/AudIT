using AudIT.Applicationa.Requests.Department.Dto;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Department.Queries.GetById;

public class GetDepartmentByIdQuery : IRequest<BaseDTOResponse<BaseDepartmentDto>>
{
    public Guid Id { get; set; }

    public GetDepartmentByIdQuery(Guid id)
    {
        Id = id;
    }
}