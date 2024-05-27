using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Department.Dto;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Department.Queries.GetById;

public class GetDepartmentByIdHandler(
    IDepartmentRepository departmentRepository,
    IMapper mapper
) : IRequestHandler<GetDepartmentByIdQuery, BaseDTOResponse<BaseDepartmentDto>>
{
    public async Task<BaseDTOResponse<BaseDepartmentDto>> Handle(GetDepartmentByIdQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await departmentRepository.FindByIdAsync(request.Id);

            if (!result.IsSuccess)
                return new BaseDTOResponse<BaseDepartmentDto>($"Department with id {request.Id} not found", false);


            return new BaseDTOResponse<BaseDepartmentDto>(mapper.Map<BaseDepartmentDto>(result.Value),
                "Succesfully retrieved department", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseDepartmentDto>($"An error occured: {e.Message}", false);
        }
    }
}