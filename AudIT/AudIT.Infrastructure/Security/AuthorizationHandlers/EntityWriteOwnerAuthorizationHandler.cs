using System.Security.Claims;
using AudIT.Domain.Misc;
using Microsoft.AspNetCore.Authorization;

namespace AudIT.Infrastructure.Security.AuthorizationHandlers;

public class EntityWriteOwnerAuthorizationHandler :
    AuthorizationHandler<EntityWriteOwnerAuthorizationHandler, AuditableEntity>,
    IAuthorizationRequirement
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        EntityWriteOwnerAuthorizationHandler requirement,
        AuditableEntity resource)
    {

        var userId = Guid.Parse(context.User.FindFirstValue(ClaimTypes.NameIdentifier));

        if (resource.WriteAccesUserId.Contains(userId))
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }

        return Task.CompletedTask;
    }
}