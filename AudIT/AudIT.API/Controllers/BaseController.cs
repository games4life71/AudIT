using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AudIT.API.Controllers;

[Route("/api/v1/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    private ISender _mediator;

    protected ISender Mediator
        => _mediator ??= (ISender)HttpContext.RequestServices.GetService(typeof(ISender));
}