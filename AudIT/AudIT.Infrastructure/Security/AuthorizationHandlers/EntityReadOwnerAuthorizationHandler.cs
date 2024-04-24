using AudIT.Domain.Misc;
using Microsoft.AspNetCore.Authorization;

namespace AudIT.Infrastructure.Security.AuthorizationHandlers;

public class EntityReadOwnerAuthorizationHandler :
    AuthorizationHandler<EntityReadOwnerAuthorizationHandler, AuditableEntity>, IAuthorizationRequirement
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        EntityReadOwnerAuthorizationHandler requirement,
        AuditableEntity resource)
    {
        var userId = Guid.Parse(context.User.Identity?.Name);

        if (resource.ReadAccesUserId.Contains(userId))
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