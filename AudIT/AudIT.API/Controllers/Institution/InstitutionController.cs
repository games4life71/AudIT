using AudIT.Applicationa.Models.Misc;
using AudIT.Applicationa.Requests.Institution.Commands.Create;
using AudIT.Applicationa.Requests.Institutions.Commands.Delete;
using AudIT.Applicationa.Requests.Institutions.Commands.Edit;
using AudIT.Applicationa.Requests.Institutions.Queries.GetAll;
using AudIT.Applicationa.Requests.Institutions.Queries.GetAllIFull;
using AudIT.Applicationa.Requests.Institutions.Queries.GetByRecommendation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AudIT.API.Controllers.Institution;

public class InstitutionController : BaseController
{
    [HttpPost]
    [Authorize(Roles = UserRoles.Unverified)]
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

    [HttpGet]
    [Route("get-institution-by-recommendation/{recommendationId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetInstitutionByRecommendation(Guid recommendationId)
    {
        var result = await Mediator.Send(new GetInstitutionByRecommendationQuery(recommendationId));
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

    [HttpGet]
    [Route("get-all-institutions")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllInstitutions()
    {
        var result = await Mediator.Send(new GetAllInstitutionsCommand());
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [HttpGet]
    [Route("get-all-institutions-full")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllInstitutionsFull()
    {
        var result = await Mediator.Send(new GetAllInstitutionsFullQuery());
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [HttpPut]
    [Route("edit-institution")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> EditInstitution(EditInstitutionCommand command)
    {
        var result = await Mediator.Send(command);
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }
}