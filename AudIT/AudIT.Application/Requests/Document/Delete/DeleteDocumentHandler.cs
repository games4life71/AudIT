using Amazon.Runtime.Documents;
using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Contracts.DocumentServices;
using AudIT.Applicationa.Responses;
using MediatR;
using DocumentType = AudIT.Domain.Misc.DocumentType;

namespace AudIT.Applicationa.Requests.Document.Delete;

public class DeleteDocumentHandler(
    IBaseDocumentRepository baseDocumentRepository,
    ITemplateDocRepository templateDocRepository,
    IStandaloneDocRepository standaloneDocRepository,
    IDocumentManager documentManager
) : IRequestHandler<DeleteDocumentCommand, BaseResponse>
{
    public async Task<BaseResponse> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var document = await baseDocumentRepository.FindByIdAsync(request.Id);

            if (!document.IsSuccess)
            {
                return new BaseResponse("Document not found", false);
            }

            var key = document.Value.Name + "." + document.Value.Extension;


            //delete the document from the s3 bucket
            var (success, message) = await documentManager.DeleteDocumentAsync(key, document.Value.DocumentType);

            if (!success)
            {
                return new BaseResponse(message, false);
            }

            //delete the document from the database
            switch (document.Value.DocumentType)
            {
                case DocumentType.Template:
                    await templateDocRepository.DeleteAsync(request.Id);
                    break;
                case DocumentType.Standalone:
                    await standaloneDocRepository.DeleteAsync(request.Id);
                    break;
            }

            return new BaseResponse("Document deleted successfully", true);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new BaseResponse(e.Message, false);
        }
    }
}