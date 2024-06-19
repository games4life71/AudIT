using AudIT.Applicationa.Requests.Export.Activity.CSV;
using AudIT.Applicationa.Requests.Export.Fiap;
using AudIT.Applicationa.Requests.Export.ObjectiveAndActions.XLS;
using Microsoft.AspNetCore.Mvc;

namespace AudIT.API.Controllers.Export;

[ApiController]
[Route("api/[controller]")]
public class ExportController : BaseController
{
    [HttpPost]
    [Route("activities/csv")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ExportActivitiesCSV([FromBody] List<Guid> activityIds)
    {
        var command = new ExportActivityCSVCommand
        {
            ActivityIds = activityIds
        };

        var response = await Mediator.Send(command);

        if (!response.Success)
        {
            return BadRequest(response.Message);
        }

        return new FileStreamResult(response.DtoResponse.ExportedData, "text/csv")
        {
            FileDownloadName = $"Activities_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.csv"
        };
    }


    [HttpGet]
    [Route("objectives-and-actions/xls/{auditMissionId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ExportObjectivesAndActionsXLS(Guid auditMissionId)
    {
        var command = new ExportObjectivesAndActionsXLSCommand
        {
            AuditMissionId = auditMissionId
        };

        var response = await Mediator.Send(command);

        if (!response.Success)
        {
            return BadRequest(response.Message);
        }

        return new FileStreamResult(response.DtoResponse.ExportedData,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
        {
            FileDownloadName = $"ObjectivesAndActions_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.xlsx"
        };
    }

    [HttpGet]
    [Route("fiap/{fiapId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ExportFiap(Guid fiapId)
    {
        var command = new ExportFiapCommand
        {
            Id = fiapId
        };

        var response = await Mediator.Send(command);

        if (!response.Success)
        {
            return BadRequest(response.Message);
        }

        return new FileStreamResult(response.DtoResponse.ExportedData,
            "application/docx")
        {
            FileDownloadName = $"FIAP_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.docx"
        };
    }
}