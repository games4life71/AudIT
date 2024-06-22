using AudIT.Applicationa.Requests.Document.Dto;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Document.Get.GetRecommendationDocuments;

public class GetDocumentsByRecommendationQuery:IRequest<BaseDTOResponse<BaseDocumentDto>>
{

    public Guid RecommendationId { get; set; }

    public GetDocumentsByRecommendationQuery(Guid recommendationId)
    {
        RecommendationId = recommendationId;
    }
}