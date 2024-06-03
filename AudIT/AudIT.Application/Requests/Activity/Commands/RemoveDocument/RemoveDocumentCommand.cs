using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Activity.Commands.RemoveDocument;

public class RemoveDocumentCommand:IRequest<BaseResponse>
{
    public Guid ActivityId { get; set; }

    public Guid DocumentId { get; set; }


    public RemoveDocumentCommand(Guid activityId, Guid documentId)
    {
        ActivityId = activityId;
        DocumentId = documentId;
    }
}