using AudIT.Applicationa.Requests.Access.ReadAcces;
using Microsoft.AspNetCore.Mvc;

namespace AudIT.API.Controllers.Access;


[ApiController]
[Route("api/[controller]")]
public class AccessController:BaseController
{


    [HttpPost]
    [Route("SetReadAccess")]
    public async Task<IActionResult> SetReadAccess([FromBody] AddReadAccesCommand command)
    {
        var result = await Mediator.Send(command);

        if (!result.Item1)
        {
            return BadRequest(result.Item2);
        }

        return Ok(result.Item2);
    }



}