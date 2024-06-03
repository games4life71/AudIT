using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.ObjectiveActions.Commands.DeleteActionRisk;

public class DeleteActionRiskHandler(
    IActionRiskRepository actionRiskRepository
) : IRequestHandler<DeleteActionRiskCommand, BaseResponse>
{
    public async Task<BaseResponse> Handle(DeleteActionRiskCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await actionRiskRepository.DeleteAsync(request.Id);

            if (!response.IsSuccess)
                return new BaseResponse()
                {
                    Success = false,
                    Message = "An error occurred while deleting the action risk"
                };

            return new BaseResponse("Action Risk deleted successfully", true);
        }
        catch (Exception e)
        {
            return new BaseResponse()
            {
                Success = false,
                Message = e.Message
            };
        }
    }
}