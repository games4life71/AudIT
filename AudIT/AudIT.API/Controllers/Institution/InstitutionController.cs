using AudIT.Applicationa.Requests.Institution.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace AudIT.API.Controllers.Institution;



public class InstitutionController:BaseController
{

    [HttpPost]
    [Route("add-institution")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddInstitution([FromBody] CreateInstitutionCommand command)
    {
        var result = await Mediator.Send(command);
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }
        return Ok(result);
    }


}