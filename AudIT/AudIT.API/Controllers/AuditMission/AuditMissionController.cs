using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.AuditMission.Commands.Create;
using AudIT.Applicationa.Requests.AuditMission.Commands.Update;
using AudIT.Applicationa.Requests.AuditMission.Queries.GetBy.GetByDepartmentId;
using AudIT.Applicationa.Requests.AuditMission.Queries.GetBy.GetByOwnerId;
using AudIT.Applicationa.Requests.AuditMission.Queries.GetById;
using AudIT.Domain.Misc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AudIT.API.Controllers.AuditMission;

public class AuditMissionController(
    IAuthorizationService authorizationService,
    IAuditMissionRepository auditMissionRepository
) : BaseController
{
    [HttpPost]
    [Route("add-audit-mission")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddAuditMission(CreateBaseAuditMIssionCommand command)
    {
        var result = await Mediator.Send(command);
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }


    [HttpGet]
    [Route("get-audit-mission/{id}")]
    // [Authorize(Policy = "EntityOwnerPolicy")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    // [Authorize]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetAuditMission(Guid id)
    {
        var result = await Mediator.Send(new GetByIdQuery(id));

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        var auditMission = await auditMissionRepository.FindByIdAsync(id);
        // var auditableEntity = (AuditableEntity)auditMission.Value;
        // var authorizationResult =
        //     await authorizationService.AuthorizeAsync(User, auditMission.Value, "EntityReadPolicy");
        //
        // if (!authorizationResult.Succeeded)
        // {
        //     return StatusCode(StatusCodes.Status403Forbidden, "You are not authorized to access this resource");
        // }


        return Ok(result);
    }


    [HttpGet]
    [Route("get-audit-mission-by-owner/{id}")]
    [Authorize(Roles = "Admin")] // only admin can access this route
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAuditMissionByOwner(Guid id)
    {
        var result = await Mediator.Send(new GetAudMissByOwnerId(id.ToString()));
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }


    [HttpGet]
    [Route("get-audit-mission-by-department/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAuditMissionByDepartment(Guid id)
    {
        var result = await Mediator.Send(new GetByDepartIdQuery(id));
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        var auditMission = await auditMissionRepository.FindByIdAsync(id);
        // var auditableEntity = (AuditableEntity)auditMission.Value;
        var authorizationResult =
            await authorizationService.AuthorizeAsync(User, auditMission.Value, "EntityReadPolicy");

        if (!authorizationResult.Succeeded)
        {
            return StatusCode(StatusCodes.Status403Forbidden, "You are not authorized to access this resource");
        }

        return Ok(result);
    }

    [HttpPut]
    [Route("update-audit-mission")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAuditMission(UpdateAuditMissionCommand command)
    {
        var result = await Mediator.Send(command);
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }
}