using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Document.TemplateDocument.DTO;
using AudIT.Applicationa.Responses;
using AudiT.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AudIT.Applicationa.Requests.Document.TemplateDocument.Commands.Create;

public class CreateTemplateDocHandler(
    ITemplateDocRepository docRepository,
    UserManager<AudiT.Domain.Entities.User> _userManager,
    IMapper _mapper) : IRequestHandler<CreateTemplateDocCommand, BaseDTOResponse<BaseTemplateDocDto>>
{
    public async Task<BaseDTOResponse<BaseTemplateDocDto>> Handle(CreateTemplateDocCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            //validate
            // var validation = await new CreateTemplateDocValidator().ValidateAsync(request, cancellationToken);

            // if (!validation.IsValid)
            // {
            //     return new BaseDTOResponse<BaseTemplateDocDto>
            //     {
            //         Message = validation.Errors.Select(x => x.ErrorMessage).ToList().ToString(),
            //         Success = false
            //     };
            // }


            //get the user
            var user = await _userManager.FindByIdAsync(request.OwnerId.ToString());

            if (user == null)
            {
                return new BaseDTOResponse<BaseTemplateDocDto>
                {
                    Message = "User not found",
                    Success = false
                };
            }


            //get the docuemnt if exists
            var name = request.Name.Split('.').First();
            var exisingDocument = await docRepository.GetTemplateDocumentByName(name);

            if (exisingDocument.IsSuccess)
            {
                //update this document , dont create a new one
                exisingDocument.Value.UpdateDocument(request.Name, request.Extension, request.State, request.Type,
                    request.Version);
                var resultUpdate = await docRepository.UpdateAsync(exisingDocument.Value);

                if (!resultUpdate.IsSuccess)
                {
                    return new BaseDTOResponse<BaseTemplateDocDto>("Failed to update the document", false);
                }


                return new BaseDTOResponse<BaseTemplateDocDto>(_mapper.Map<BaseTemplateDocDto>(resultUpdate.Value),
                    "Document updated successfully", true);
            }


            //create the document

            var new_doc = AudiT.Domain.Entities.TemplateDocument.Create(
                request.Name,
                request.Extension,
                user,
                request.OwnerId,
                request.State,
                request.Type,
                request.Version
            );
            if (!new_doc.IsSuccess)
            {
                return new BaseDTOResponse<BaseTemplateDocDto>("Failed to create the document", false);
            }

            //save the document
            var result = await docRepository.AddAsync(new_doc.Value);

            if (!result.IsSuccess)
            {
                return new BaseDTOResponse<BaseTemplateDocDto>("Failed to save the document", false);
            }
            else
            {
                return new BaseDTOResponse<BaseTemplateDocDto>(_mapper.Map<BaseTemplateDocDto>(result.Value),
                    "Successfully created the template document", true);
            }
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseTemplateDocDto>(e.Message, false);
        }
    }
}