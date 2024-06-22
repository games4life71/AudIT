using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.RecommendationDocument.Command;

public class CreateRecommendationDocumentCommand:IRequest<BaseResponse>
{
    public Guid RecommendationId { get; set; }

    public Guid  BaseDocumentId { get; set; }

    public CreateRecommendationDocumentCommand(Guid recommendationId, Guid baseDocumentId)
    {
        RecommendationId = recommendationId;
        BaseDocumentId = baseDocumentId;
    }


}