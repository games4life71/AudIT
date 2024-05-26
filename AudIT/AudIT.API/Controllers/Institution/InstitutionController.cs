using AudIT.Applicationa.Models.Misc;
using AudIT.Applicationa.Requests.Institution.Commands.Create;
using AudIT.Applicationa.Requests.Institutions.Commands.Delete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AudIT.API.Controllers.Institution;



public class InstitutionController:BaseController
{

    [HttpPost]
    [Authorize(Roles =UserRoles.Unverified)]
    [Route("add-institution")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddInstitution([FromBody] CreateInstitutionCommand command)
    {
        //get the info of the user


        var result = await Mediator.Send(command);
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }
        return Ok(result);

    }

    [HttpDelete]
    [Route("delete-institution/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteInstitution(Guid id)
    {
        var result = await Mediator.Send(new DeleteCommand(id));
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }
        return Ok(result);
    }

}