using System.Text;
using System.Web;
using AudIT.Applicationa.Requests.Document.StandaloneDocument.Commands.Create;
using AudIT.Applicationa.Requests.Document.StandaloneDocument.Commands.Download;
using AudIT.Applicationa.Requests.Document.StandaloneDocument.Commands.Upload;
using Microsoft.AspNetCore.Mvc;

namespace AudIT.API.Controllers.Document;

public class StandaloneDocumentController : BaseController
{
    /// <summary>
    /// Endpoint to create a standalone document in the database
    /// </summary>
    /// <param name="uploadDocument"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("create-standalone-document")]
    public async Task<IActionResult> CreateStandaloneDocument(IFormFile uploadDocument,
        [FromForm] CreateStandDocumentCommand command)
    {
        try
        {
            //upload the document to s3 bucket
            StringBuilder key = new StringBuilder();
            var fileExtension = uploadDocument.FileName.Split('.').Last();
            key.Append("standalone-documents/");
            key.Append(uploadDocument.FileName.Split('.').First());
            key.Append('.');
            key.Append(fileExtension);
            Console.WriteLine("THE KEY IS " + key.ToString());
            var uploadResult = Mediator.Send(new UploadStandDoc(uploadDocument, key.ToString()));

            if (!uploadResult.Result.Item1)
            {
                return BadRequest("Failed to upload document");
            }

            //proceed to save it to database if it was successful


            var result = await Mediator.Send(new CreateStandDocumentCommand()
            {
                Name = uploadDocument.FileName.Split('.').First(),
                OwnerId = command.OwnerId,
                DepartmentId = command.DepartmentId,
                Extension = fileExtension
            });


            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.DtoResponse);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPost]
    [Route("upload-standalone-documents")]
    public async Task<IActionResult> UploadStandaloneDocuments(List<IFormFile> uploadDocuments,
        [FromForm] CreateStandDocumentCommand command)
    {
        try
        {
            foreach (var file in uploadDocuments)
            {
                StringBuilder key = new StringBuilder();
                var fileExtension = file.FileName.Split('.').Last();
                key.Append("standalone-documents/");
                key.Append(file.FileName.Split('.').First());
                key.Append('.');
                key.Append(fileExtension);

                var uploadResult = Mediator.Send(new UploadStandDoc(file, key.ToString()));

                if (!uploadResult.Result.Item1)
                {
                    return BadRequest("Failed to upload document");
                }

                //save it to database if it was successful
                var result = await Mediator.Send(new CreateStandDocumentCommand()
                {
                    Name = file.FileName.Split('.').First(),
                    OwnerId = command.OwnerId,
                    DepartmentId = command.DepartmentId,
                    Extension = fileExtension
                });
            }
        }

        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok("Documents uploaded successfully");
    }


    [HttpGet]
    [Route("{key}")]
    public async Task<IActionResult> GetStandaloneDocument(string key)
    {
        try
        {
            //decodes the key to get the actual file name
            key = HttpUtility.UrlDecode(key);
            //append the standalone-documents/ to the key
            key = "standalone-documents/" + key;
            var result = await Mediator.Send(new DownloadCommand(key));
            if (!result.Item1)
            {
                return BadRequest("Failed to download document");
            }

            //return File(result.Item2.ResponseStream, result.Item2.Headers.ContentType, key);
            return new FileStreamResult(result.Item2.ResponseStream, result.Item2.Headers.ContentType);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}