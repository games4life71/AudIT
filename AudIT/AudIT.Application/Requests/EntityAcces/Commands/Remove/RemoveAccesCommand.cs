using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.EntityAcces.Commands.Remove;

public class RemoveAccesCommand:IRequest<BaseResponse>
{
    public Guid Id { get; set; }

    public RemoveAccesCommand(Guid id)
    {
        Id = id;
    }
}
