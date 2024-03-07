using AudIT.Domain.Misc;
using Microsoft.AspNetCore.Authorization;

namespace AudIT.Infrastructure.Security.AuthorizationHandlers;

public class EntityOwnerAuthorizationHandler:AuthorizationHandler<EntityOwnerAuthorizationHandler,AuditableEntity>, IAuthorizationRequirement
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EntityOwnerAuthorizationHandler requirement,
        AuditableEntity resource)
    {
        if (context.User.Identity?.Name == resource.CreatedBy)
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