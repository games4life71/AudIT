using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Department.Dto;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Department.Queries.GetByInstitutionId;

public class GetDepartmentByInstIDHandler(
    IDepartmentRepository departmentRepository,
    IMapper mapper
) : IRequestHandler<GetDepartmentByInstitutionIdQuery, BaseDTOResponse<BaseDepartmentDto>>
{
    public async Task<BaseDTOResponse<BaseDepartmentDto>> Handle(GetDepartmentByInstitutionIdQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await departmentRepository.FindByInstitutionIdAsync(
                request.InstitutionId);
            if (!result.IsSuccess)
                return new BaseDTOResponse<BaseDepartmentDto>(
                    $"Department with institution id {request.InstitutionId} not found", false);
            return new BaseDTOResponse<BaseDepartmentDto>(mapper.Map<BaseDepartmentDto>(result.Value),
                "Succesfully retrieved department", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseDepartmentDto>($"An error occured: {e.Message}", false);
        }
    }
}