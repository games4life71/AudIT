using AudIT.Applicationa.Requests.Activity.Commands.Add;
using AudIT.Applicationa.Requests.Activity.Commands.AttachDocument;
using AudIT.Applicationa.Requests.Activity.Commands.RemoveDocument;
using AudIT.Applicationa.Requests.Activity.Commands.Update;
using AudIT.Applicationa.Requests.Activity.Queries;
using AudIT.Applicationa.Requests.Activity.Queries.GetByDate;
using Microsoft.AspNetCore.Mvc;

namespace AudIT.API.Controllers.Activity;

[ApiController]
public class ActivityController : BaseController
{
    [HttpPost]
    [Route("add-activity")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddActivity(CreateActivityCommand command)
    {
        var result = await Mediator.Send(command);


        if (!result.Success)
            return BadRequest(result.Message);


        return Ok(result);
    }


    [HttpPost]
    [Route("attach-document")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AttachDocument(AttachDocumentCommand command)
    {
        var result = await Mediator.Send(command);


        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [HttpGet]
    [Route("get-activity/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetActivity(Guid id)
    {
        var result = await Mediator.Send(new GetActivityByIdQuery(id));


        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }


    [HttpDelete]
    [Route("remove-document")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> RemoveDocument(RemoveDocumentCommand command)
    {
        var result = await Mediator.Send(command);

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }


    [HttpGet]
    [Route("get-activity-by-date")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetActivityByDate(DateTime startDate, DateTime endDate)
    {
        var result = await Mediator.Send(new GetActivityByDateCommand(startDate, endDate));

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }


    [HttpPut]
    [Route("update-activity")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateActivity(UpdateActivityCommand command)
    {
        var result = await Mediator.Send(command);

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }
}