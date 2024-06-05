using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActionFiap.Commands.Delete;

public class DeleteFiapHandler(
    IObjectiveActionFiapRepository repository
) : IRequestHandler<DeleteFiapCommand, BaseResponse>
{
    public async Task<BaseResponse> Handle(DeleteFiapCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await repository.DeleteAsync(request.FiapId);

            if (!result.IsSuccess)
            {
                return new BaseResponse("Failed to delete Fiap", false);
            }

            return new BaseResponse("Fiap deleted successfully", true);
        }
        catch (Exception e)
        {
            return new BaseResponse(e.Message, false);
        }
    }
}