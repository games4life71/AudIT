using AudIT.Applicationa.Requests.Document.Dto;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Document.Get.GetRecentDocumentByUserId;

public class GetRecentDocumentsByUserIdQuery(Guid userId) : IRequest<BaseDTOResponse<BaseDocumentDto>>
{
    public Guid UserId { get; set; } = userId;
}