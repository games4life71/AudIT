using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Department.Dto;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Department.Command.Update;

public class UpdateDepartmentHandler(
    IDepartmentRepository departmentRepository,
    IMapper mapper
) : IRequestHandler<UpdateDepartmentCommand, BaseDTOResponse<BaseDepartmentDto>>
{
    public async Task<BaseDTOResponse<BaseDepartmentDto>> Handle(UpdateDepartmentCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var department = await departmentRepository.FindByIdAsync(request.Id);


            if (!department.IsSuccess)
            {
                return new BaseDTOResponse<BaseDepartmentDto>($"Cannot find department with this id {request.Id}",
                    false);
            }

            department.Value.Update(
                request.Name,
                request.Adress,
                request.PhoneNumber
            );

            var updateRes = await departmentRepository.UpdateAsync(department.Value);

            if (!updateRes.IsSuccess)
            {
                return new BaseDTOResponse<BaseDepartmentDto>("Cannot update department", false);
            }

            return new BaseDTOResponse<BaseDepartmentDto>(mapper.Map<BaseDepartmentDto>(updateRes.Value), "Succes",
                true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseDepartmentDto>($"An error occured: {e.Message}", false);
        }
    }
}