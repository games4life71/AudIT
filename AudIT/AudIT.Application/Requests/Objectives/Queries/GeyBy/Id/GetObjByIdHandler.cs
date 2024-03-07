using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Objectives.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Objectives.Queries.GeyBy.Id;

public class GetObjByIdHandler(
    IObjectiveRepository objectiveRepository,
    IObjectiveActionRepository objectiveActionRepository,
    IActionRiskRepository actionRiskRepository,
    IMapper mapper) : IRequestHandler<GetObjByIdQuery, BaseDTOResponse<ObjectiveCompleteDto>>
{
    public async Task<BaseDTOResponse<ObjectiveCompleteDto>> Handle(GetObjByIdQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var objective = await objectiveRepository.FindByIdAsync(request.Id);
            if (!objective.IsSuccess)
            {
                return new BaseDTOResponse<ObjectiveCompleteDto>($"Objective with id {request.Id} not found", false);
            }

            var objectiveActions = await objectiveActionRepository.FindAllByObjectiveIdAsync(request.Id);


            var objectiveDto = new ObjectiveCompleteDto(
                objective.Value.Id,
                objective.Value.Name,
                objective.Value.AuditMissionId,
                objectiveActions.Value
            );

            return new BaseDTOResponse<ObjectiveCompleteDto>(objectiveDto, "Succes", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<ObjectiveCompleteDto>(e.Message, false);
        }
    }
}