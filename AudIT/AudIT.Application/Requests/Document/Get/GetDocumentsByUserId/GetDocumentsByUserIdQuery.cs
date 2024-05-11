using Amazon.Runtime.Internal;
using AudIT.Applicationa.Requests.Document.Dto;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Document.Get.GetDocumentsByUserId;

public class GetDocumentsByUserIdQuery : IRequest<BaseDTOResponse<BaseDocumentDto>>
{
    public Guid UserId { get; set; }

    public GetDocumentsByUserIdQuery(Guid userId)
    {
        UserId = userId;
    }
}