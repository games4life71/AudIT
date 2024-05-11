using AudIT.Applicationa.Requests.Document.Get.GetDocumentsByUserId;
using Microsoft.AspNetCore.Mvc;

namespace AudIT.API.Controllers.Document;

public class BaseDocumentController : BaseController
{
    [HttpGet]
    [Route("get-documents-by-user-id/{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetDocumentsByUserId(Guid userId)
    {
        var result = await Mediator.Send(new GetDocumentsByUserIdQuery(userId));

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }


        return Ok(result);
    }
}