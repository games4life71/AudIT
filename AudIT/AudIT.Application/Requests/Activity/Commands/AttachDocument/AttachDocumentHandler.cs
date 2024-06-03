using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Activity.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Activity.Commands.AttachDocument;

public class AttachDocumentHandler(
    IActivityRepository activityRepository,
    IBaseDocumentRepository documentRepository,
    IMapper mapper
) : IRequestHandler<AttachDocumentCommand, BaseDTOResponse<ActivityWIthDocumentsDto>>
{
    public async Task<BaseDTOResponse<ActivityWIthDocumentsDto>> Handle(AttachDocumentCommand request,
        CancellationToken cancellationToken)
    {
        //verify if the document exists
        try
        {

            var document = await documentRepository.FindByIdAsync(request.BaseDocumentId);
            if (!document.IsSuccess)
            {
                return new BaseDTOResponse<ActivityWIthDocumentsDto>($"Document with id {request.BaseDocumentId} not found",
                    false);
            }

            var result = activityRepository.AttachDocumentAsync(request.ActivityId, document.Value);

            if (!result.Result.IsSuccess)
            {
                return new BaseDTOResponse<ActivityWIthDocumentsDto>(result.Result.Error, false);
            }

            var fullActivity = await activityRepository.FindByIdAsync(request.ActivityId);
            Console.WriteLine("count of attached :"+ fullActivity.Value.AttachedDocuments.Count);
            var activity = mapper.Map<ActivityWIthDocumentsDto>(fullActivity.Value);

            return new BaseDTOResponse<ActivityWIthDocumentsDto>(activity);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<ActivityWIthDocumentsDto>(e.Message, false);
        }
    }
}