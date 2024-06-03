using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Objective.DTO;
using AudIT.Applicationa.Requests.Objectives.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Objectives.Queries.GeyBy.GetByAuditMissionId;

public class GetObjByAuditMissionIdHandler(
    IObjectiveRepository objectiveRepository,
    IMapper mapper
) : IRequestHandler<GetObjectiveByAuditMissionIdQuery, BaseDTOResponse<BaseObjectiveDto>>
{
    public async Task<BaseDTOResponse<BaseObjectiveDto>> Handle(GetObjectiveByAuditMissionIdQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await objectiveRepository.FindAllByAuditMissionIdAsync(request.AuditMissionId);


            if (!result.IsSuccess)
            {
                return new BaseDTOResponse<BaseObjectiveDto>($"Cannot find objective for audit mission with id" +
                                                             $"{request.AuditMissionId}", false);
            }


            var objectives = result.Value;

            var mappedObjectives = mapper.Map<List<BaseObjectiveDto>>(objectives);

            return new BaseDTOResponse<BaseObjectiveDto>(mappedObjectives, "Succes", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseObjectiveDto>($"An error occured: {e.Message}", false);
        }
    }
}