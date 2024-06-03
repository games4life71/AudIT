using AudIT.Applicationa.Requests.AuditMission.Queries.GetById;
using AudIT.Applicationa.Requests.Department.Queries.GetById;
using AudIT.Applicationa.Requests.Department.Queries.GetByInstitutionId;
using Microsoft.AspNetCore.Mvc;

namespace AudIT.API.Controllers.Department;

public class DepartmentController : BaseController
{
    [HttpGet]
    [Route("get-department/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetDepartment(Guid id)
    {
        var result = await Mediator.Send(new GetDepartmentByIdQuery(id));

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }


    [HttpGet]
    [Route("get-departments-by-institution-id/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetDepartmentByInstitutionId(Guid id)
    {
        var result = await Mediator.Send(new GetDepartmentsByInstitutionIdQuery { InstitutionId = id });

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }
}