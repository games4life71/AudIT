using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Objectives.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Objectives.Queries.GeyBy.GetByAuditMissionId;

public class GetObjByAuditMissionIdHandler(
    IObjectiveRepository objectiveRepository,
    IMapper mapper
) : IRequestHandler<GetObjectiveByAuditMissionIdQuery, BaseDTOResponse<ObjectiveCompleteDto>>
{
    public async Task<BaseDTOResponse<ObjectiveCompleteDto>> Handle(GetObjectiveByAuditMissionIdQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await objectiveRepository.FindAllByAuditMissionIdAsync(request.AuditMissionId);


            if (!result.IsSuccess)
            {
                return new BaseDTOResponse<ObjectiveCompleteDto>($"Cannot find objective for audit mission with id" +
                                                                 $"{request.AuditMissionId}", false);
            }


            var objectives = result.Value;

            var mappedObjectives = mapper.Map<List<ObjectiveCompleteDto>>(objectives);

            return new BaseDTOResponse<ObjectiveCompleteDto>(mappedObjectives, "Succes", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<ObjectiveCompleteDto>($"An error occured: {e.Message}", false);
        }
    }
}