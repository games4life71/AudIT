using Amazon.S3.Model;
using AudIT.Applicationa.Contracts.DocumentServices;
using MediatR;

namespace AudIT.Applicationa.Requests.Document.StandaloneDocument.Commands.Download;

public class DownloadHandler(IDocumentManager _manager) : IRequestHandler<DownloadCommand, (bool, GetObjectResponse)>
{
    public async Task<(bool, GetObjectResponse)> Handle(DownloadCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return await _manager.GetDocumentAsync(request.Key);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return (false, null);
        }
    }
}