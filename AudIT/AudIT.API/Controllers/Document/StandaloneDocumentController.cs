using System.Text;
using AudIT.Applicationa.Requests.Document.StandaloneDocument.Commands.Create;
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
            key.Append(command.Name);
            key.Append('.');
            key.Append(fileExtension);

            var uploadResult = Mediator.Send(new UploadStandDoc(uploadDocument, key.ToString()));

            if (!uploadResult.Result)
            {
                return BadRequest("Failed to upload document");
            }

            //proceed to save it to database if it was successful


            var result = await Mediator.Send(new CreateStandDocumentCommand()
            {
                 Name = command.Name,
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
}