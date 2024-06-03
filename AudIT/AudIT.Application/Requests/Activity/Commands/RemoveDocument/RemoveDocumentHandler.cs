using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Activity.Commands.RemoveDocument;

public class RemoveDocumentHandler(
    IActivityRepository activityRepository,
    IBaseDocumentRepository documentRepository
) : IRequestHandler<RemoveDocumentCommand, BaseResponse>
{
    public async Task<BaseResponse> Handle(RemoveDocumentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var activity = await activityRepository.FindByWithDocumentsAsync(request.ActivityId);

            if (!activity.IsSuccess)
            {
                return new BaseResponse($"Activity with id {request.ActivityId} not found", false);
            }

            var document = activity.Value.AttachedDocuments.FirstOrDefault(x => x.Id == request.DocumentId);

            if (document == null)
            {
                return new BaseResponse($"Document with id {request.DocumentId} not found", false);
            }

            var result = await activityRepository.RemoveDocumentAsync(request.ActivityId, request.DocumentId);

            return result.IsSuccess
                ? new BaseResponse(result.Error, true)
                : new BaseResponse(result.Error, false);
        }
        catch (Exception e)
        {
            return new BaseResponse(e.Message, false);
        }
    }
}