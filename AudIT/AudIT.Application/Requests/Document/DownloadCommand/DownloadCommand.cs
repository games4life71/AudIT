using Amazon.S3.Model;
using MediatR;

namespace AudIT.Applicationa.Requests.Document.StandaloneDocument.Commands.Download;

public class DownloadCommand(string key):IRequest<(bool,GetObjectResponse)>
{
    public string Key { get; set; } = key;
}