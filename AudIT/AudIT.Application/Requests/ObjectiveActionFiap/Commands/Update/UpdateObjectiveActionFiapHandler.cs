using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.ObjectiveActionFiap.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActionFiap.Commands.Update;

public class UpdateObjectiveActionFiapHandler(
    IObjectiveActionFiapRepository objectiveActionFiapRepository,
    IMapper mapper
) : IRequestHandler<UpdateObjectiveActionFiapCommand, BaseDTOResponse<BaseObjActionFiapDto>>
{
    public async Task<BaseDTOResponse<BaseObjActionFiapDto>> Handle(UpdateObjectiveActionFiapCommand request,
        CancellationToken cancellationToken)
    {
        //Get the ObjectiveActionFiap from the database

        try
        {
            var objActionFiap = await objectiveActionFiapRepository.FindByIdAsync(request.Id);

            if (!objActionFiap.IsSuccess)
            {
                return new BaseDTOResponse<BaseObjActionFiapDto>(
                    $"Cannot find ObjectiveActionFiap with id {request.Id}",
                    false);
            }

            objActionFiap.Value.Update(
                name: request.Name,
                auditedPeriodStart: request.AuditedPeriodStart,
                auditedPeriodEnd: request.AuditedPeriodEnd,
                problem: request.Problem,
                recommendation: request.Recommendation,
                aditionalFindings: request.AditionalFindings,
                cause: request.Cause,
                consequence: request.Consequence
            );

            var updatedResult = await objectiveActionFiapRepository.UpdateAsync(objActionFiap.Value);

            if (!updatedResult.IsSuccess)
            {
                return new BaseDTOResponse<BaseObjActionFiapDto>(
                    $"Cannot update ObjectiveActionFiap with id {request.Id}",
                    false);
            }


            return new BaseDTOResponse<BaseObjActionFiapDto>(mapper.Map<BaseObjActionFiapDto>(updatedResult.Value),
                "ObjectiveActionFiap updated successfully", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseObjActionFiapDto>(
                $"An error occurred when updating ObjectiveActionFiap with id {request.Id}: {e.Message}",
                false);
        }
    }
}