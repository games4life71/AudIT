using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Notification.Commands.Update.SetAsRead;

public class SetNotificationReadCommand:IRequest<BaseResponse>
{
    public Guid Id { get; set; }

    public SetNotificationReadCommand(Guid id)
    {
        Id = id;
    }
}