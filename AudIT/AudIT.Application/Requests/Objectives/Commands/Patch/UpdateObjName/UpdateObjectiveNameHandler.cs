using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Objective.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Objectives.Commands.Patch.UpdateObjName;

public class UpdateObjectiveNameHandler(
    IObjectiveRepository objectiveRepository,
    IMapper mapper
) : IRequestHandler<UpdateObjectiveNameCommand, BaseDTOResponse<BaseObjectiveDto>>
{
    public async Task<BaseDTOResponse<BaseObjectiveDto>> Handle(UpdateObjectiveNameCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var objective = await objectiveRepository.FindByIdAsync(request.Id);


            if (!objective.IsSuccess)
            {
                return new BaseDTOResponse<BaseObjectiveDto>
                {
                    Message = $"Failed to find objective with id {request.Id}",
                    Success = false
                };
            }


            objective.Value.Update(request.Name);

            var updatedObjective = await objectiveRepository.UpdateAsync(objective.Value);

            if (!updatedObjective.IsSuccess)
            {
                return new BaseDTOResponse<BaseObjectiveDto>
                {
                    Message = $"Failed to update objective with id {request.Id}",
                    Success = false
                };
            }

            return new BaseDTOResponse<BaseObjectiveDto>
            {
                Success = true,
                DtoResponse = mapper.Map<BaseObjectiveDto>(updatedObjective.Value),
                Message = $"Successfully updated objective with id {request.Id}"
            };
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseObjectiveDto>
            {
                Message = $"An error occured : {e.Message}",
                Success = false
            };
        }
    }
}