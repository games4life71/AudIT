using MediatR;
using Microsoft.AspNetCore.Http;

namespace AudIT.Applicationa.Requests.Document.StandaloneDocument.Commands.Upload;

public class UploadStandDoc : IRequest<bool>
{
    private readonly string FolderName = "StandaloneDocs";
    private readonly string BucketName = "auditdocbucket";

    public IFormFile File { get; set; }

    /// <summary>
    /// This is the name of the document;
    /// It will contain the name_version.extension of the document
    /// </summary>
    public string Key { get; set; }


    public UploadStandDoc(IFormFile file, string key)
    {
        File = file;
        Key = key;
    }
}