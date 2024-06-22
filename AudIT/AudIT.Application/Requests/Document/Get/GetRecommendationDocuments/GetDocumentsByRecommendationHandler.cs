using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Document.Dto;
using AudIT.Applicationa.Responses;
using AudIT.Domain.Misc;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Document.Get.GetRecommendationDocuments;

public class GetDocumentsByRecommendationHandler(
    IRecommendationDocumentRepository recommendationDocumentRepository,
    IBaseDocumentRepository documentRepository,
    IMapper mapper
) : IRequestHandler<GetDocumentsByRecommendationQuery, BaseDTOResponse<BaseDocumentDto>>
{
    public async Task<BaseDTOResponse<BaseDocumentDto>> Handle(GetDocumentsByRecommendationQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var recommendationDocuments =
                await recommendationDocumentRepository.FindByRecommendationId(request.RecommendationId);

            if (!recommendationDocuments.IsSuccess)
            {
                return new BaseDTOResponse<BaseDocumentDto>("No recommendation documents found", false);
            }


            //get the documents

            List<BaseDocument> documents = [];

            foreach (var recommendationDocument in recommendationDocuments.Value)
            {
                var document = await documentRepository.FindByIdAsync(recommendationDocument.BaseDocumentId);
                if (document.IsSuccess)
                {
                    documents.Add(document.Value);
                }
            }

            var baseDocumentDtos = mapper.Map<List<BaseDocumentDto>>(documents);


            return new BaseDTOResponse<BaseDocumentDto>(baseDocumentDtos, "Recommendation documents found", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseDocumentDto>(e.Message, false);
        }
    }
}