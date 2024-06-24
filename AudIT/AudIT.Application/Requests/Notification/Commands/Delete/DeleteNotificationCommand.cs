using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Notification.Commands.Delete;

public class DeleteNotificationCommand : IRequest<BaseResponse>
{
    public Guid Id { get; set; }

    public DeleteNotificationCommand(Guid id)
    {
        Id = id;
    }
}