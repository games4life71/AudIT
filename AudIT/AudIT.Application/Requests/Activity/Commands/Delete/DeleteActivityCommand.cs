using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Activity.Commands.Delete;

public class DeleteActivityCommand : IRequest<BaseResponse>
{
    public Guid Id { get; set; }

    public DeleteActivityCommand(Guid id)
    {
        Id = id;
    }
}