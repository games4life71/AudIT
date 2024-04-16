using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Recommendations.DTO;
using AudIT.Applicationa.Responses;
using AudiT.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Recommendations.Commands.Create;

public class CreateRecommendationHandler(
    IRecommendationRepository recommendationRepository,
    IObjectiveActionRepository objectiveActionRepository,
    IMapper mapper
) : IRequestHandler<CreateRecommendationCommand, BaseDTOResponse<BaseRecommendationDTO>>
{
    public async Task<BaseDTOResponse<BaseRecommendationDTO>> Handle(CreateRecommendationCommand request,
        CancellationToken cancellationToken)
    {
        var objAction = await objectiveActionRepository.FindByIdAsync(request.ObjectiveActionId);

        if (!objAction.IsSuccess)
        {
            return new BaseDTOResponse<BaseRecommendationDTO>("Objective Action not found", false);
        }

        var newRecommendation = Recommendation.Create(request.Description, request.DueDate, request.ObjectiveActionId,
            objAction.Value);

        if (!newRecommendation.IsSuccess)
            return new BaseDTOResponse<BaseRecommendationDTO>(newRecommendation.Error, false);

        var result = await recommendationRepository.AddAsync(newRecommendation.Value);

        if (!result.IsSuccess)
            return new BaseDTOResponse<BaseRecommendationDTO>(result.Error, false);

        return new BaseDTOResponse<BaseRecommendationDTO>(mapper.Map<BaseRecommendationDTO>(result.Value),
            "Recommendation created successfully", true);
    }
}