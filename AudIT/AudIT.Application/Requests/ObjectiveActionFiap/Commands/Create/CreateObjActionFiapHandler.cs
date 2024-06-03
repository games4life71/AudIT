using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.ObjectiveActionFiap.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActionFiap.Commands.Create;

public class CreateObjActionFiapHandler(
    IObjectiveActionFiapRepository objectiveActionFiapRepository,
    IAuditMissionRepository auditMissionRepository,
    IObjectiveActionRepository objectiveActionRepository,
    IRecommendationRepository recommendationRepository,
    IMapper mapper
) : IRequestHandler<CreateObjActionFiapCommand, BaseDTOResponse<BaseObjActionFiapDto>>
{
    public async Task<BaseDTOResponse<BaseObjActionFiapDto>> Handle(CreateObjActionFiapCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var auditMission = await auditMissionRepository.FindByIdAsync(request.AuditMissionId);

            if (!auditMission.IsSuccess)
            {
                return new BaseDTOResponse<BaseObjActionFiapDto>(
                    $"Audit Mission with id {request.AuditMissionId} not found", false);
            }

            var objectiveAction = await objectiveActionRepository.FindByIdAsync(request.ObjectiveActionId);

            if (!objectiveAction.IsSuccess)
            {
                return new BaseDTOResponse<BaseObjActionFiapDto>(
                    $"Objective Action with id {request.ObjectiveActionId} not found", false);
            }


            var newObjActionFiap = AudiT.Domain.Entities.ObjectiveActionFiap.Create(
                request.Name,
                request.AuditMissionId,
                request.ObjectiveActionId,
                request.AuditedPeriodStart,
                request.AuditedPeriodEnd,
                request.Problem,
                request.Recommendation,
                auditMission.Value,
                objectiveAction.Value,
                request.AditionalFindings,
                request.Cause,
                request.Consequence
            );

            if (!newObjActionFiap.IsSuccess)
            {
                return new BaseDTOResponse<BaseObjActionFiapDto>(
                    $"Cannot create Objective Action FIAP: {newObjActionFiap.Error}", false);
            }

            var objResult = await objectiveActionFiapRepository.AddAsync(newObjActionFiap.Value);

            if (!objResult.IsSuccess)
            {
                return new BaseDTOResponse<BaseObjActionFiapDto>(
                    $"Cannot insert into DB {objResult.Error}", false);
            }

            //automatially create a new Recommendation for the ObjectiveActionFiap

            var newRecommendation = AudiT.Domain.Entities.Recommendation.Create(
                request.Recommendation,
                DateTime.Now,
                request.Problem,
                request.AditionalFindings,
                request.Cause,
                request.Consequence,
                request.Recommendation,
                newObjActionFiap.Value.ObjectiveAction,
                newObjActionFiap.Value.ObjectiveActionId
            );

            var resultRecommendation = await recommendationRepository.AddAsync(newRecommendation.Value);

            if (!resultRecommendation.IsSuccess)
            {
                return new BaseDTOResponse<BaseObjActionFiapDto>(
                    $"Cannot insert into DB {resultRecommendation.Error}", false);
            }




            return new BaseDTOResponse<BaseObjActionFiapDto>(mapper.Map<BaseObjActionFiapDto>(newObjActionFiap.Value),
                "succesfully created", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseObjActionFiapDto>($"An error occured: {e.Message}", false);
        }
    }
}