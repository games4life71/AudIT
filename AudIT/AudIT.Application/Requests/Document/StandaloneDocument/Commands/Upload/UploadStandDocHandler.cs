using AudIT.Applicationa.Contracts.DocumentServices;
using MediatR;

namespace AudIT.Applicationa.Requests.Document.StandaloneDocument.Commands.Upload;

public class UploadStandDocHandler(IDocumentManager _documentManager) : IRequestHandler<UploadStandDoc, bool>
{
    public async Task<bool> Handle(UploadStandDoc request, CancellationToken cancellationToken)
    {
        //use the document manager to upload the document

        try
        {
            var (success, message) = await _documentManager.UploadDocumentAsync(request.File, request.Key);

            if (!success)
            {
                return false;
            }

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}