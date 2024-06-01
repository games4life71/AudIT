using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.ObjectiveActionFiap.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActionFiap.Queries.GetByAuditMissionId;

public class GetFiapByAuditMissionIHandler(
    IObjectiveActionFiapRepository objectiveActionFiapRepository,
    IMapper mapper
) : IRequestHandler<GetFiapByAuditMissionIdQuery, BaseDTOResponse<BaseObjActionFiapDto>>
{
    public async Task<BaseDTOResponse<BaseObjActionFiapDto>> Handle(GetFiapByAuditMissionIdQuery request,
        CancellationToken cancellationToken)
    {
        if (request.MostRecent)
        {
            var result = await
                objectiveActionFiapRepository.GetMostRecentAsyncById(x => x.LastModifiedDate,
                    x=>x.AuditMissionId==request.AuditMissionId,
                    request.AuditMissionId,
                    3);

            if (!result.IsSuccess)
            {
                return new BaseDTOResponse<BaseObjActionFiapDto>("No entities found.", false);
            }

            var mappedResult = mapper.Map<List<BaseObjActionFiapDto>>(result.Value);

            return new BaseDTOResponse<BaseObjActionFiapDto>(mappedResult, "Succes", true);
        }

        else
        {
            // var result =
            await objectiveActionFiapRepository.GetByFilterAsync(x => x.AuditMissionId == request.AuditMissionId);
            var result =  await objectiveActionFiapRepository.GetAllAsync();
            if (!result.IsSuccess)
            {
                return new BaseDTOResponse<BaseObjActionFiapDto>("No entities found.", false);
            }

            var mappedResult = mapper.Map<List<BaseObjActionFiapDto>>(result.Value);

            return new BaseDTOResponse<BaseObjActionFiapDto>(mappedResult, "Succes", true);
        }
    }
}