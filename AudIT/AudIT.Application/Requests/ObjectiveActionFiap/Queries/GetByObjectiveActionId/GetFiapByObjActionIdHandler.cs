using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.ObjectiveActionFiap.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActionFiap.Queries.GetByObjectiveActionId;

public class GetFiapByObjActionIdHandler(
    IObjectiveActionFiapRepository objectiveActionFiapRepository,
    IMapper mapper
) : IRequestHandler<GetFiapByObjActionIdQuery, BaseDTOResponse<BaseObjActionFiapDto>>
{
    public async Task<BaseDTOResponse<BaseObjActionFiapDto>> Handle(GetFiapByObjActionIdQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await objectiveActionFiapRepository.GetAllByObjActionId(request.ObjectiveActionId);

            if (!result.IsSuccess)
            {
                return new BaseDTOResponse<BaseObjActionFiapDto>(
                    $"Canno find Fiap for ObjectiveActionId: {request.ObjectiveActionId}", false);
            }


            return new BaseDTOResponse<BaseObjActionFiapDto>(mapper.Map<List<BaseObjActionFiapDto>>(result.Value), "succes",
                true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseObjActionFiapDto>(e.Message, false);
        }
    }
}