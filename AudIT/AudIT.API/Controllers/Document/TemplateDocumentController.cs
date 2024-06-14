using System.Security.Claims;
using System.Text;
using System.Web;
using AudIT.Applicationa.Requests.Document.StandaloneDocument.Commands.Download;
using AudIT.Applicationa.Requests.Document.StandaloneDocument.Commands.Upload;
using AudIT.Applicationa.Requests.Document.TemplateDocument.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace AudIT.API.Controllers.Document;

public class TemplateDocumentController : BaseController
{
    [HttpPost]
    [Route("upload-template-documents")]
    public async Task<IActionResult> UploadTemplateDocuments(List<IFormFile> files,
        [FromForm] CreateTemplateDocCommand command)
    {
        try
        {
            foreach (var file in files)
            {



                StringBuilder key = new StringBuilder();
                var fileExtension = file.FileName.Split('.').Last();
                key.Append("template-documents/");
                key.Append(file.FileName.Split('.').First());
                key.Append('.');
                key.Append(fileExtension);
                Console.WriteLine("The key is "  + key.ToString());
                var uploadResult = Mediator.Send(new UploadStandDoc(file, key.ToString()));

                if (!uploadResult.Result.Item1)
                {
                    return BadRequest("Failed to upload the document");
                }

                //save the document to the database
                command.Extension = fileExtension;
                command.Name = file.FileName.Split('.').First();
                command.Version = uploadResult.Result.Item2;

                var userId = this.HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier);

                command.OwnerId = Guid.Parse(userId.Value);

                var result = await Mediator.Send(command);

                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }


            }
            return Ok("Document uploaded successfully");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return BadRequest("Failed to upload the document");
    }


    [HttpGet]
    [Route("{key}")]
    public async Task<IActionResult> GetTemplateDocument(string key)
    {
        try
        {
            key = HttpUtility.UrlDecode(key);
            //append the template-documents/ to the key
            key = "template-documents/" + key;
            var result = await Mediator.Send(new DownloadCommand(key));

            if (!result.Item1)
            {
                return BadRequest("Failed to download the document");
            }

            return new FileStreamResult(result.Item2.ResponseStream, result.Item2.Headers.ContentType);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}