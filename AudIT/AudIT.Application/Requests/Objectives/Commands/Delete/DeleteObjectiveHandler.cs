using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Objective.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Objectives.Commands.Delete;

public class DeleteObjectiveHandler(IObjectiveRepository repository)
    : IRequestHandler<DeleteObjectiveCommand, BaseResponse>
{
    public async Task<BaseResponse> Handle(DeleteObjectiveCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var objective = await repository.FindByIdAsync(request.Id);
            if (!objective.IsSuccess)
            {
                return new BaseDTOResponse<BaseObjectiveDto>("Objective not found.", false);
            }

            await repository.DeleteAsync(objective.Value.Id);
            return new BaseResponse("Objective deleted successfully.", true);
        }
        catch (Exception e)
        {
            return new BaseResponse(e.Message, false);
        }
    }
}