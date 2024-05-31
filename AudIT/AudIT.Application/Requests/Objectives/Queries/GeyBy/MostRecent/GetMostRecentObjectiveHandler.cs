using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Objective.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Objectives.Queries.GeyBy.MostRecent;

public class GetMostRecentObjectiveHandler(
    IObjectiveRepository objectiveRepository,
    IMapper mapper
) : IRequestHandler<GetMostRecentObjByAuditMissionIdQuery, BaseDTOResponse<BaseObjectiveDto>>
{
    public async Task<BaseDTOResponse<BaseObjectiveDto>> Handle(GetMostRecentObjByAuditMissionIdQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await objectiveRepository.FindMostRecentsByAuditMissionIdAsync(request.AuditMissionId);

            if (!result.IsSuccess)
            {
                return new BaseDTOResponse<BaseObjectiveDto>("Objectives not found", false);
            }

            var objectives = mapper.Map<List<BaseObjectiveDto>>(result.Value);


            return new BaseDTOResponse<BaseObjectiveDto>(objectives, "Succes", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseObjectiveDto>(e.Message, false);
        }
    }
}