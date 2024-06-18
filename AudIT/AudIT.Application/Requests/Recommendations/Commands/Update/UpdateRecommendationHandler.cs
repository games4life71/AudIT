using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Recommendations.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Recommendations.Commands.Update;

public class UpdateRecommendationHandler(
    IRecommendationRepository recommendationRepository,
    IObjectiveActionFiapRepository objectiveActionFiapRepository,
    IMapper mapper
) : IRequestHandler<UpdateRecommendationCommmand, BaseDTOResponse<BaseRecommendationDTO>>
{
    public async Task<BaseDTOResponse<BaseRecommendationDTO>> Handle(UpdateRecommendationCommmand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var recommendation = await recommendationRepository.FindByIdAsync(request.Id);

            if (!recommendation.IsSuccess)
            {
                return new BaseDTOResponse<BaseRecommendationDTO>($"Failed to find recommendation with id {request.Id}",
                    false);
            }

            recommendation.Value.Update(
                request.Description,
                request.DueDate,
                request.Problem,
                request.AditionalFindings,
                request.Cause,
                request.Consequence,
                request.RecommendationDescription
            );

            var updateResult = await recommendationRepository.UpdateAsync(recommendation.Value);

            if (!updateResult.IsSuccess)
            {
                return new BaseDTOResponse<BaseRecommendationDTO>(
                    $"Failed to update recommendation with id {request.Id}", false);
            }

            //update the fiap

            var objectiveActionFiap =
                await objectiveActionFiapRepository.GetByFilterAsync(x => x.ObjectiveActionId == recommendation.Value.ObjectiveActionId);


            if (!objectiveActionFiap.IsSuccess)
            {
                return new BaseDTOResponse<BaseRecommendationDTO>(
                    $"Failed to find objective action fiap with id {recommendation.Value.ObjectiveActionId}", false);
            }

            foreach (var objFiap in objectiveActionFiap.Value)
            {
                objFiap.Update(
                    request.Description,
                    DateTime.Now,
                    request.DueDate,
                    request.AditionalFindings,
                    request.Cause,
                    request.Consequence,
                    request.RecommendationDescription
                );

                var updateFiapResult = await objectiveActionFiapRepository.UpdateAsync(objFiap);

                if (!updateFiapResult.IsSuccess)
                {
                    return new BaseDTOResponse<BaseRecommendationDTO>(
                        $"Failed to update objective action fiap with id {recommendation.Value.ObjectiveActionId}", false);
                }

            }

            return new BaseDTOResponse<BaseRecommendationDTO>(mapper.Map<BaseRecommendationDTO>(recommendation.Value),
                "Succes", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseRecommendationDTO>(
                $"An error occurred when updating recommendation with id {request.Id}: {e.Message}", false);
        }
    }
}