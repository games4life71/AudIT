using AudIT.Applicationa.Contracts.DocumentServices;
using MediatR;

namespace AudIT.Applicationa.Requests.Document.StandaloneDocument.Commands.Upload;

public class UploadDocHandler(IDocumentManager _documentManager) : IRequestHandler<UploadStandDoc, (bool, string)>
{
    /// <summary>
    /// This method handles the upload of the document command
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>A tuple containing (succes,version)</returns>
    public async Task<(bool, string)> Handle(UploadStandDoc request, CancellationToken cancellationToken)
    {
        //use the document manager to upload the document

        try
        {
            var (success, message, version) = await _documentManager.UploadDocumentAsync(request.File, request.Key);

            if (!success)
            {
                return (false, "0");
            }

            return (true, version);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return (false, "0");
        }
    }
}