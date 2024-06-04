using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Department.Dto;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Department.Command.Create;

public class CreateDepartmentHandler(
    IDepartmentRepository departmentRepository,
    IInstitutionRepository institutionRepository,
    IMapper mapper
) : IRequestHandler<CreateDepartmentCommand, BaseDTOResponse<BaseDepartmentDto>>
{
    public async Task<BaseDTOResponse<BaseDepartmentDto>> Handle(CreateDepartmentCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var institution = await institutionRepository.FindByIdAsync(request.InstitutionId);

            if (!institution.IsSuccess)
            {
                return new BaseDTOResponse<BaseDepartmentDto>
                {
                    Success = false,
                    Message = $"Institution with id {request.InstitutionId} not found"
                };
            }


            var newDepart = AudiT.Domain.Entities.Department.Create(
                request.Name,
                request.Adress,
                request.PhoneNumber,
                institution.Value
            );

            var added = await departmentRepository.AddAsync(newDepart.Value);

            if (!added.IsSuccess)
            {
                return new BaseDTOResponse<BaseDepartmentDto>
                {
                    Success = false,
                    Message = "Failed to add department"
                };
            }

            return new BaseDTOResponse<BaseDepartmentDto>
            {
                Success = true,
                DtoResponse = mapper.Map<BaseDepartmentDto>(added.Value),
                Message = "Department added successfully"
            };
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseDepartmentDto>
            {
                Success = false,
                Message = e.Message
            };
        }
    }
}