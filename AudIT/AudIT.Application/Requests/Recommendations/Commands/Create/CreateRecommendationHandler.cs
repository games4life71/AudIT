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
    IAuditMissionRecommendationsRepository auditMissionRecommendationsRepository,
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

        var newRecommendation = Recommendation.Create(
            request.Description,
            request.DueDate,
            request.Problem,
            request.AditionalFindings,
            request.Cause,
            request.Consequence,
            request.RecommendationDescription,
            objAction.Value,
            request.ObjectiveActionId
        );

        if (!newRecommendation.IsSuccess)
            return new BaseDTOResponse<BaseRecommendationDTO>(newRecommendation.Error, false);

        var result = await recommendationRepository.AddAsync(newRecommendation.Value);

        if (!result.IsSuccess)
            return new BaseDTOResponse<BaseRecommendationDTO>(result.Error, false);

        //add the reccomendation to the AuditMissionRecommendation table

        var auditMission = await objectiveActionRepository.GetAuditMissionByObjectiveActionId(objAction.Value.Id);

        if (!auditMission.IsSuccess)
        {
            return new BaseDTOResponse<BaseRecommendationDTO>("Audit Mission not found", false);
        }

        var auditMissionRecommendation = AuditMissionRecommendations.Create(
            auditMission.Value,
            result.Value
        );

        var auditMissionRecommendationResult = await auditMissionRecommendationsRepository.AddAsync(auditMissionRecommendation.Value);

        if (!auditMissionRecommendationResult.IsSuccess)
        {
            return new BaseDTOResponse<BaseRecommendationDTO>(auditMissionRecommendationResult.Error, false);
        }




        return new BaseDTOResponse<BaseRecommendationDTO>(mapper.Map<BaseRecommendationDTO>(result.Value),
            "Recommendation created successfully", true);
    }
}