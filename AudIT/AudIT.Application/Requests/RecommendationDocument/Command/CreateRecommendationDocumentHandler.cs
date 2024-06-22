using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.RecommendationDocument.Command;

public class CreateRecommendationDocumentHandler(
    IBaseDocumentRepository baseDocumentRepository,
    IRecommendationDocumentRepository recommendationDocumentRepository,
    IRecommendationRepository recommendationRepository
) : IRequestHandler<CreateRecommendationDocumentCommand, BaseResponse>
{
    public async Task<BaseResponse> Handle(CreateRecommendationDocumentCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var recommendation = await recommendationRepository.FindByIdAsync(request.RecommendationId);

            if (!recommendation.IsSuccess)
            {
                return new BaseResponse("Recommendation not found", false);
            }

            var baseDocument = await baseDocumentRepository.FindByIdAsync(request.BaseDocumentId);

            if (!baseDocument.IsSuccess)
            {
                return new BaseResponse("Base Document not found", false);
            }

            var newRecommendationDocument = AudiT.Domain.Entities.RecommendationDocument.Create(
                recommendation.Value.Id,
                baseDocument.Value.Id
            );

            var result = await recommendationDocumentRepository.AddAsync(newRecommendationDocument.Value);

            if (!result.IsSuccess)
            {
                return new BaseResponse("Failed to create recommendation document", false);
            }

            return new BaseResponse("Recommendation document created successfully", true);
        }
        catch (Exception e)
        {
            return new BaseResponse(e.Message, false);
        }
    }
}