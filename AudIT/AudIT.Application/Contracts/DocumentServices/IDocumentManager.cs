using Microsoft.AspNetCore.Http;

namespace AudIT.Applicationa.Contracts.DocumentServices;



/// <summary>
/// This interface is used to manage the document upload/request from the amazonm s3 bucket
///
/// </summary>
public interface IDocumentManager
{

    public Task<(bool,string)>UploadDocumentAsync(IFormFile file, string key);

    //TODO in future change the return type to a model that will contain the document and the key to the document
    public Task<(bool,string)> GetDocumentAsync(string key);

    public Task<(bool,string)> DeleteDocumentAsync(string key);

    public Task<(bool,string)> UpdateDocumentAsync(string key, IFormFile file);

}