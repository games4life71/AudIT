using System.Security.Claims;
using AudIT.Applicationa.Requests.RecommendationDocument.Command;
using AudIT.Applicationa.Requests.Recommendations.Commands.Create;
using AudIT.Applicationa.Requests.Recommendations.Commands.Delete;
using AudIT.Applicationa.Requests.Recommendations.Commands.Patch;
using AudIT.Applicationa.Requests.Recommendations.Commands.Update;
using AudIT.Applicationa.Requests.Recommendations.Queries.GetAllByAuditMission;
using AudIT.Applicationa.Requests.Recommendations.Queries.GetAllRecentsByUser;
using AudIT.Applicationa.Requests.Recommendations.Queries.GetById;
using AudiT.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AudIT.API.Controllers.Recommendation;

[ApiController]
[Route("api/[controller]")]
public class RecommendationController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> CreateRecommendation(CreateRecommendationCommand request)
    {
        var result = await Mediator.Send(request);
        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [HttpGet]
    [Route("get-recent-by-user")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetRecentRecommendationsByUser()
    {
        var userID = this.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        if (userID == null)
            return Unauthorized();

        var result = await Mediator.Send(new GetRecentRecommendationsByUserQuery(Guid.Parse(userID)));
        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [HttpPost]
    [Route("create-recommendation-document")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> CreateRecommendationDocument(CreateRecommendationDocumentCommand request)
    {
        var result = await Mediator.Send(request);
        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRecommendationById(Guid id)
    {
        var result = await Mediator.Send(new GetRecommendationById(id));
        if (!result.Success)

            return BadRequest(result.Message);

        return Ok(result);
    }

    [HttpPatch]
    public async Task<IActionResult> SetRecommendationStatus(SetRecommendationStatusCommand request)
    {
        var result = await Mediator.Send(request);
        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [HttpGet]
    [Route("get-all-by-audit-mission/{auditMissionId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetRecommendationsByAuditMission(Guid auditMissionId)
    {
        var result = await Mediator.Send(new GetRecommendationsByAuditMissionCommand(auditMissionId));
        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [HttpPut]
    [Route("update-recommendation")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> UpdateRecommendation(UpdateRecommendationCommmand request)
    {
        var result = await Mediator.Send(request);
        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }

    [HttpDelete]
    [Route("delete-recommendation/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> DeleteRecommendation(Guid id)
    {
        var result = await Mediator.Send(new DeleteRecommendationCommand(id));
        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }
}