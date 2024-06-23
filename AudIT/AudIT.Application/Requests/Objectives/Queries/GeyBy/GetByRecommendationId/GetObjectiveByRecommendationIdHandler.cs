using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Objective.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Objectives.Queries.GeyBy.GetByRecommendationId;

public class GetObjectiveByRecommendationIdHandler(
    IObjectiveRepository objectiveRepository,
    IMapper mapper,
    IAuditMissionRecommendationsRepository auditMissionRecommendationsRepository,
    IObjectiveActionRepository objectiveActionRepository
) : IRequestHandler<GetObjectiveByRecommendationIdQuery, BaseDTOResponse<BaseObjectiveDto>>
{
    public async Task<BaseDTOResponse<BaseObjectiveDto>> Handle(GetObjectiveByRecommendationIdQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var auditMissionRecommendation =
                await auditMissionRecommendationsRepository.GetAuditMissionByRecommendationId(request.RecommendationId);


            if (!auditMissionRecommendation.IsSuccess)
            {
                return new BaseDTOResponse<BaseObjectiveDto>("Audit mission not found ", false);
            }


            var objective =
                await objectiveRepository.FindObjectiveByObjectiveActionId(auditMissionRecommendation.Value
                    .Recommendation
                    .ObjectiveActionId);

            if (!objective.IsSuccess)
            {
                return new BaseDTOResponse<BaseObjectiveDto>("Objective not found ", false);
            }

            var objectiveDto = mapper.Map<BaseObjectiveDto>(objective.Value);

            return new BaseDTOResponse<BaseObjectiveDto>(objectiveDto);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseObjectiveDto>(e.Message, false);
        }

        // var objective = await objectiveRepository.Fi(auditMission.Value.Id);
    }
}