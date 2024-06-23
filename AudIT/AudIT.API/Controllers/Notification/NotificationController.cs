using AudIT.Applicationa.Requests.Notification.Commands.Create;
using AudIT.Applicationa.Requests.Notification.Commands.Update.SetAsRead;
using AudIT.Applicationa.Requests.Notification.Queries.GetByInstitution;
using Microsoft.AspNetCore.Mvc;

namespace AudIT.API.Controllers.Notification;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : BaseController
{
    [HttpPost]
    [Route("create-notification")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateNotification(CreateNotificationCommand command)
    {
        var result = await Mediator.Send(command);

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [HttpGet]
    [Route("get-notifications-by-institution-id/{institutionId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetNotificationsByInstitutionId(Guid institutionId)
    {
        var result = await Mediator.Send(new GetNotificationsByInstitutionIdQuery(institutionId));

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [HttpPost]
    [Route("set-notification-read/{notificationId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> SetNotificationRead(Guid notificationId)
    {
        var result = await Mediator.Send(new SetNotificationReadCommand(notificationId));

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }
}