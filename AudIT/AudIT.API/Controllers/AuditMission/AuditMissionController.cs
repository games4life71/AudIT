﻿using AudIT.Applicationa.Requests.AuditMission.Commands.Create;
using AudIT.Applicationa.Requests.AuditMission.Queries.GetBy.GetByDepartmentId;
using AudIT.Applicationa.Requests.AuditMission.Queries.GetBy.GetByOwnerId;
using AudIT.Applicationa.Requests.AuditMission.Queries.GetById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AudIT.API.Controllers.AuditMission;

public class AuditMissionController : BaseController
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
    public async Task<IActionResult> GetAuditMission(Guid id)
    {
        var result = await Mediator.Send(new GetByIdQuery(id));
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }


    [HttpGet]
    [Route("get-audit-mission-by-owner/{id}")]
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

        return Ok(result);
    }
}