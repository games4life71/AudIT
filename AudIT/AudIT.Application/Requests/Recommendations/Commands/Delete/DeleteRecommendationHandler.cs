using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Recommendations.Commands.Delete;

public class DeleteRecommendationHandler(
    IRecommendationRepository recommendationRepository,
    IAuditMissionRecommendationsRepository auditMissionRecommendationsRepository

) : IRequestHandler<DeleteRecommendationCommand, BaseResponse>
{
    public async Task<BaseResponse> Handle(DeleteRecommendationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var recommendation = await recommendationRepository.DeleteAsync(request.Id);

            if (!recommendation.IsSuccess)
            {
                return new BaseResponse($"Cannot delete recommendation with id: {request.Id}", false);
            }

            var auditMissionRecommendation = await auditMissionRecommendationsRepository.DeleteByRecommendationId(request.Id);

            return new BaseResponse("Recommendation deleted successfully", true);
        }
        catch (Exception e)
        {
            return new BaseResponse($"An error occurred: {e.Message}", false);
        }
    }
}