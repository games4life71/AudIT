using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.ObjectiveActionFiap.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActionFiap.Commands.Queries.GetById;

public class GetObjActionByIdHandler(
    IObjectiveActionFiapRepository objectiveActionFiapRepository,
    IMapper mapper
) : IRequestHandler<GetObjActionFiapByIdQuery, BaseDTOResponse<BaseObjActionFiapDto>>
{
    public async Task<BaseDTOResponse<BaseObjActionFiapDto>> Handle(GetObjActionFiapByIdQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await objectiveActionFiapRepository.FindByIdAsync(request.Id);

            if (!result.IsSuccess)
            {
                return new BaseDTOResponse<BaseObjActionFiapDto>(
                    $"Objective Action FIAP with id {request.Id} not found",
                    false);
            }


            return new BaseDTOResponse<BaseObjActionFiapDto>(mapper.Map<BaseObjActionFiapDto>(result.Value), "Success",
                true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseObjActionFiapDto>($"An error occurred: {e.Message}", false);
        }
    }
}