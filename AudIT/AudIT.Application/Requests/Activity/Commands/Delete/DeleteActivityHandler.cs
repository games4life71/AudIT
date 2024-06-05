using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Responses;
using MediatR;
using Microsoft.AspNetCore.DataProtection.Internal;

namespace AudIT.Applicationa.Requests.Activity.Commands.Delete;

public class DeleteActivityHandler(
    IActivityRepository _activityRepository
) : IRequestHandler<DeleteActivityCommand, BaseResponse>
{
    public async Task<BaseResponse> Handle(DeleteActivityCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _activityRepository.DeleteAsync(request.Id);

            if (!response.IsSuccess)
            {
                return new BaseResponse("Cannot delete activity", false);
            }

            return new BaseResponse("Activity deleted successfully", true);
        }
        catch (Exception e)
        {
            return new BaseResponse(e.Message, false);
        }
    }
}