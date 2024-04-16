using AudIT.Applicationa.Requests.Export.Activity.CSV;
using Microsoft.AspNetCore.Mvc;

namespace AudIT.API.Controllers.Export;

[ApiController]
[Route("api/[controller]")]
public class ExportController:BaseController
{



    [HttpGet]
    public async Task<IActionResult> ExportActivitiesCSV([FromQuery] List<Guid> activityIds)
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
    
}