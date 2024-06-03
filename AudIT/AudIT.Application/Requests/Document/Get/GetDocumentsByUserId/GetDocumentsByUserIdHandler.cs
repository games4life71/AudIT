using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Document.Dto;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Document.Get.GetDocumentsByUserId;

public class GetDocumentsByUserIdHandler(
    IBaseDocumentRepository _documentRepository,
    IMapper _mapper
) : IRequestHandler<GetDocumentsByUserIdQuery, BaseDTOResponse<BaseDocumentDto>>
{
    public async Task<BaseDTOResponse<BaseDocumentDto>> Handle(GetDocumentsByUserIdQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var documents = await _documentRepository.GetDocumentsByUserId(request.UserId);


            if (!documents.IsSuccess)
                return new BaseDTOResponse<BaseDocumentDto>(
                    $"Failed to retrieve documents created by user with id {request.UserId}", false);


            //map the documents to the dto

            var documentsDto = _mapper.Map<List<BaseDocumentDto>>(documents.Value);


            return new BaseDTOResponse<BaseDocumentDto>(documentsDto,
                $"Successfully retrieved documents created by user with id {request.UserId}", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseDocumentDto>(
                $"An error occurred while retrieving documents created by user with id {request.UserId}: {e.Message}",
                false);
        }
    }
}