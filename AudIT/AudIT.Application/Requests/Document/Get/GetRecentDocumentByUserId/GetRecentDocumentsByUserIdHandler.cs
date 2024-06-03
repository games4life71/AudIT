using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Document.Dto;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Document.Get.GetRecentDocumentByUserId;

public class GetRecentDocumentsByUserIdHandler(
    IBaseDocumentRepository baseDocumentRepository,
    IMapper mapper
) : IRequestHandler<GetRecentDocumentsByUserIdQuery, BaseDTOResponse<BaseDocumentDto>>
{
    public async Task<BaseDTOResponse<BaseDocumentDto>> Handle(GetRecentDocumentsByUserIdQuery request,
        CancellationToken cancellationToken)
    {
        var result = await baseDocumentRepository.GetRecentDocumentsByUserIdAsync(request.UserId);

        if (!result.IsSuccess)
            return new BaseDTOResponse<BaseDocumentDto>("Cannot find documents ", false);

        var response = mapper.Map<List<BaseDocumentDto>>(result.Value);


        return new BaseDTOResponse<BaseDocumentDto>(response, "Documents found successfully", true);
    }
}