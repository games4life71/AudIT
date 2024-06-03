using AudIT.Applicationa.Requests.Activity.DTO;
using AudIT.Applicationa.Responses;
using AudIT.Domain.Misc;
using MediatR;

namespace AudIT.Applicationa.Requests.Activity.Commands.AttachDocument;

public class AttachDocumentCommand : IRequest<BaseDTOResponse<ActivityWIthDocumentsDto>>
{
    public Guid ActivityId { get; set; }

    public Guid BaseDocumentId { get; set; }

    public AttachDocumentCommand(Guid activityId, Guid baseDocumentId)
    {
        ActivityId = activityId;
        BaseDocumentId = baseDocumentId;
    }
}