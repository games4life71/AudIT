using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Document.TemplateDocument.Commands.Delete;

public class DeleteCommand : IRequest<BaseResponse>
{
    public Guid Id { get; set; }

    public DeleteCommand(Guid id)
    {
        Id = id;
    }
}