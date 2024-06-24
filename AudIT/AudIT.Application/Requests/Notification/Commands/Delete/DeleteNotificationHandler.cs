using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Notification.Commands.Delete;

public class DeleteNotificationHandler(
    INotificationRepository notificationRepository
) : IRequestHandler<DeleteNotificationCommand, BaseResponse>
{
    public async Task<BaseResponse> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
    {
        try
        {

            var deleteResult = await notificationRepository.DeleteAsync(request.Id);

            if (!deleteResult.IsSuccess)
            {
                return new BaseResponse("Cannot delete notification", false);
            }

            return new BaseResponse("Notification deleted successfully", true);
        }
        catch (Exception e)
        {
            return new BaseResponse(e.Message, false);
        }
    }
}