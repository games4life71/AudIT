using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Document.Dto;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Document.Get.GetDocumentsByDepartmentID;

public class GetDocumentsByDepartmentHandler(
    IBaseDocumentRepository documentRepository,
    IMapper mapper
) : IRequestHandler<GetDocumentsByDepartmentIdQuery, BaseDTOResponse<DocumentWithDepartmentDto>>
{
    public async Task<BaseDTOResponse<DocumentWithDepartmentDto>> Handle(GetDocumentsByDepartmentIdQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var documents = await documentRepository.GetDocumentsByDepartmentId(request.DepartmentId);

            if (!documents.IsSuccess)
                return new BaseDTOResponse<DocumentWithDepartmentDto>(
                    $"Failed to get documents by department id: {documents.Error}", false);


            //mapping the documents to the dto

            var documentsDto = mapper.Map<List<DocumentWithDepartmentDto>>(documents.Value);


            return new BaseDTOResponse<DocumentWithDepartmentDto>(documentsDto, "Documents retrieved successfully",
                true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<DocumentWithDepartmentDto>($"An error occurred: {e.Message}", false);
        }
    }
}