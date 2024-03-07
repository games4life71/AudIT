using AudIT.Applicationa.Requests.Objective.Commands.Create;
using AudIT.Applicationa.Requests.Objectives.Queries.GeyBy.Id;
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

    [HttpGet]
    [Route("get-objective-by-id")]
    public async Task<IActionResult> GetObjectiveById(Guid id)
    {
        try
        {
            var response = await Mediator.Send(new GetObjByIdQuery(id));
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