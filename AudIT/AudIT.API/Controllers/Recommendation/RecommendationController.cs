using AudIT.Applicationa.Requests.Recommendations.Commands.Create;
using AudIT.Applicationa.Requests.Recommendations.Commands.Patch;
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

}