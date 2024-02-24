using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Document.StandaloneDocument.DTO;
using AudIT.Applicationa.Responses;
using AudiT.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AudIT.Applicationa.Requests.Document.StandaloneDocument.Commands.Create;

public class CreateStandDocHandler(
    UserManager<User> _userManager,
    IDepartmentRepository _departmentRepository,
    IStandaloneDocRepository _standaloneDocumentRepository,
    IMapper _mapper
) : IRequestHandler<CreateStandDocumentCommand, BaseDTOResponse<BaseStandaloneDto>>
{
    public async Task<BaseDTOResponse<BaseStandaloneDto>> Handle(CreateStandDocumentCommand request,
        CancellationToken cancellationToken)
    {
        //validate the request
        var validator = await new CreateStandDocumentValidation().ValidateAsync(request, cancellationToken);

        if (!validator.IsValid)
        {
            return new BaseDTOResponse<BaseStandaloneDto>("Invalid request", false);
        }

        //get the user who is creating the document
        var user = await _userManager.FindByIdAsync(request.OwnerId.ToString());
        if (user == null)
        {
            return new BaseDTOResponse<BaseStandaloneDto>
            {
                Message = "User not found",
                Success = false
            };
        }

        //get the department where the document is being created
        var department = await _departmentRepository.FindByIdAsync(request.DepartmentId);
        if (!department.IsSuccess)
        {
            return new BaseDTOResponse<BaseStandaloneDto>
            {
                Message = "Department not found",
                Success = false
            };
        }

        //create the document
        var newDocument = AudiT.Domain.Entities.StandaloneDocument.Create(
            request.Name,
            request.Extension,
            user,
            request.OwnerId,
            department.Value,
            request.DepartmentId
        );

        if (!newDocument.IsSuccess)
        {
            return new BaseDTOResponse<BaseStandaloneDto>("Document failed to create", false);
        }

        //save the document
        var result = await _standaloneDocumentRepository.AddAsync(newDocument.Value);

        if (!result.IsSuccess)
        {
            return new BaseDTOResponse<BaseStandaloneDto>("Document failed to save", false);
        }

        //return the document
        return new BaseDTOResponse<BaseStandaloneDto>(_mapper.Map<BaseStandaloneDto>(newDocument.Value),
            "Document created successfully ! ", true);
    }
}