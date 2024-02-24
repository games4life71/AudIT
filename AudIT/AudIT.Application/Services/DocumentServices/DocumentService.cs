using System.Net;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using AudIT.Applicationa.Contracts.DocumentServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace AudIT.Applicationa.Services.DocumentServices;

public class DocumentService(IConfiguration _configuration) : IDocumentManager
{
    /// <summary>
    /// Uploads a file to the s3 bucket
    /// </summary>
    /// <param name="file">File to be uploaded to the s3 bucket</param>
    /// <returns></returns>
    public async Task<(bool, string)> UploadDocumentAsync(IFormFile file, string key)
    {
        var client = new AmazonS3Client(RegionEndpoint.EUCentral1);
        var bucketName = _configuration["AWS:S3:BucketName"];

        try
        {
            var post_request = new PutObjectRequest()
            {
                Key = key,
                BucketName = bucketName,
                InputStream = file.OpenReadStream(),
                ContentType = file.ContentType
            };

            var response = await client.PutObjectAsync(post_request);
            return (response.HttpStatusCode == HttpStatusCode.OK, response.HttpStatusCode.ToString());
        }

        catch (Exception e)
        {
            Console.WriteLine(e);
            return (false, e.Message);
        }
    }

    public async Task<(bool, string)> GetDocumentAsync(string key)
    {
        throw new NotImplementedException();
    }

    public async Task<(bool, string)> DeleteDocumentAsync(string key)
    {
        throw new NotImplementedException();
    }

    public async Task<(bool, string)> UpdateDocumentAsync(string key, IFormFile file)
    {
        throw new NotImplementedException();
    }
}