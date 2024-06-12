using AudIT.Applicationa.Responses;
using AudIT.Domain.Misc;
using MediatR;

namespace AudIT.Applicationa.Requests.Document.Delete;

public class DeleteDocumentCommand:IRequest<BaseResponse>
{
    public Guid Id { get; set; }



    public DeleteDocumentCommand(Guid id)
    {
        Id = id;
    }
}