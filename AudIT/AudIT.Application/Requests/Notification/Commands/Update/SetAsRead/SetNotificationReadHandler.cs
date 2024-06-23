using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Notification.Commands.Update.SetAsRead;

public class SetNotificationReadHandler(
    INotificationRepository notificationRepository
) : IRequestHandler<SetNotificationReadCommand, BaseResponse>
{
    public async Task<BaseResponse> Handle(SetNotificationReadCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var notification = await notificationRepository.FindByIdAsync(request.Id);

            if (!notification.IsSuccess)
            {
                return new BaseResponse("Notification not found", false);
            }

            notification.Value.SetRead();


            var result = await notificationRepository.UpdateAsync(notification.Value);

            if (result.IsSuccess)
            {
                return new BaseResponse("Notification updated successfully", true);
            }

            return new BaseResponse("Failed to update notification", false);
        }
        catch (Exception e)
        {
            return new BaseResponse(e.Message, false);
        }
    }
}