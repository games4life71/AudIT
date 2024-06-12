using Amazon.S3.Model;
using AudIT.Domain.Misc;
using Microsoft.AspNetCore.Http;

namespace AudIT.Applicationa.Contracts.DocumentServices;

/// <summary>
/// This interface is used to manage the document upload/request from the amazonm s3 bucket
///
/// </summary>
public interface IDocumentManager
{
    public Task<(bool, string,string)> UploadDocumentAsync(IFormFile file, string key);


    public Task<(bool, GetObjectResponse)> GetDocumentAsync(string key);

    public Task<(bool, string)> DeleteDocumentAsync(string key,DocumentType documentType);

    public Task<(bool, string)> UpdateDocumentAsync(string key, IFormFile file);
    Task<(bool success, string message, string version)> UploadBigDocumentAsync(IFormFile requestFile, string requestKey, bool b);
}