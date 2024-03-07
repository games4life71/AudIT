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
    private readonly AmazonS3Client _client = new AmazonS3Client(RegionEndpoint.EUCentral1);
    private readonly string _bucketName = _configuration["AWS:S3:BucketName"];


    /// <summary>
    /// Uploads a file to the s3 bucket
    /// </summary>
    /// <param name="file">File to be uploaded to the s3 bucket</param>
    /// <returns>A tuple (succes,message,version)</returns>
    public async Task<(bool, string, string)> UploadDocumentAsync(IFormFile file, string key)
    {
        try
        {
            var postRequest = new PutObjectRequest()
            {
                Key = key,
                BucketName = _bucketName,
                InputStream = file.OpenReadStream(),
                ContentType = file.ContentType
            };

            var response = await _client.PutObjectAsync(postRequest);

            return (response.HttpStatusCode == HttpStatusCode.OK, response.HttpStatusCode.ToString(),
                response.VersionId);
        }

        catch (Exception e)
        {
            Console.WriteLine(e);
            return (false, e.Message, "0");
        }
    }

    public async Task<(bool, GetObjectResponse)> GetDocumentAsync(string key)
    {
        try
        {
            Console.WriteLine("THE KEY IS DASADASD" + key);
            var request = new GetObjectRequest
            {
                BucketName = _bucketName,
                Key = key
            };

            var response = await _client.GetObjectAsync(request);


            return (response.HttpStatusCode == HttpStatusCode.OK, response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return (false, null);
        }
    }

    public async Task<(bool, string)> DeleteDocumentAsync(string key)
    {
        throw new NotImplementedException();
    }

    public async Task<(bool, string)> UpdateDocumentAsync(string key, IFormFile file)
    {
        throw new NotImplementedException();
    }

    public async Task<(bool success, string message, string version)> UploadBigDocumentAsync(IFormFile requestFile,
        string requestKey, bool b)
    {
        var initRequest = new InitiateMultipartUploadRequest
        {
            BucketName = _bucketName,
            Key = requestKey
        };

        var initResponse = await _client.InitiateMultipartUploadAsync(initRequest);

        var uploadPartResponses = new List<UploadPartResponse>();

        const int partSize = 5 * 1024 * 1024;
        var partNumber = 1;
        await using var stream = requestFile.OpenReadStream();
        var buffer = new byte[partSize];
        var bytesRead = 0;

        while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
        {
            var uploadRequest = new UploadPartRequest
            {
                BucketName = _bucketName,
                Key = requestKey,
                UploadId = initResponse.UploadId,
                PartNumber = partNumber,
                PartSize = bytesRead,
                InputStream = new MemoryStream(buffer)
            };

            var uploadResponse = await _client.UploadPartAsync(uploadRequest);
            
            uploadPartResponses.Add(uploadResponse);
            partNumber++;
        }

        var completeRequest = new CompleteMultipartUploadRequest
        {
            BucketName = _bucketName,
            Key = requestKey,
            UploadId = initResponse.UploadId,
            PartETags = uploadPartResponses.Select(x => new PartETag(x.PartNumber, x.ETag)).ToList()
        };

        var completeResponse = await _client.CompleteMultipartUploadAsync(completeRequest);

        return (completeResponse.HttpStatusCode == HttpStatusCode.OK, completeResponse.HttpStatusCode.ToString(),
            completeResponse.VersionId);
    }
}