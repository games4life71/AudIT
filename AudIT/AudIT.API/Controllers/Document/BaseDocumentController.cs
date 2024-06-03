using System.Security.Claims;
using AudIT.Applicationa.Requests.Document.Get.GetDocumentsByUserId;
using AudIT.Applicationa.Requests.Document.Get.GetRecentDocumentByUserId;
using Microsoft.AspNetCore.Mvc;

namespace AudIT.API.Controllers.Document;

public class BaseDocumentController : BaseController
{
    [HttpGet]
    [Route("get-documents-by-user-id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetDocumentsByUserId()
    {
        var id = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        if(id == null)
        {
            return BadRequest("User not found");
        }

        var result = await Mediator.Send(new GetDocumentsByUserIdQuery(Guid.Parse(id.Value)));

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }


        return Ok(result);
    }

    [HttpGet]
    [Route("get-recent-documents-by-user-id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetRecentDocumentsByUserId()
    {
        var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

        if (userId == null)
        {
            return BadRequest("User not found");
        }
        var result = await Mediator.Send(new GetRecentDocumentsByUserIdQuery(Guid.Parse(userId.Value)));

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }
}