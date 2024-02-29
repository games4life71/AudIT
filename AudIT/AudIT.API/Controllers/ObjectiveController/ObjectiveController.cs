using AudIT.Applicationa.Requests.Objective.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace AudIT.API.Controllers.ObjectiveController;

public class ObjectiveController : BaseController
{
    [HttpPost]
    [Route("add-new-objective")]
    public async Task<IActionResult> AddNewObjective([FromBody] CreateObjectiveCommand command)
    {
        try
        {
            var response = await Mediator.Send(command);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}