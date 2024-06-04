using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudiT.Domain.Entities;
using AudIT.Domain.Misc;
using Microsoft.EntityFrameworkCore;

namespace AudIT.Infrastructure.Repositories;

public class CurrentUserAuditMissionRepository(AudITContext context)
    : BaseRepository<CurrentUsersAuditMission>(context), ICurrentUserAuditMissioRepo
{
    private readonly AudITContext _context = context;

    public async Task<Result<CurrentUsersAuditMission>> GetCurrentUserAuditMissionAsync(string userId)
    {
        var result = await _context.CurrentUsersAuditMission.FirstOrDefaultAsync(x => x.UserId.Equals(userId));

        if (result == null)
        {
            return Result<CurrentUsersAuditMission>.Failure("No audit mission found for the current user");
        }

        return Result<CurrentUsersAuditMission>.Success(result);
    }

    public async Task<Result<CurrentUsersAuditMission>> SetCurrentUserAuditMissionAsync(string userId,
        Guid auditMissionId)
    {
        var result = await _context.CurrentUsersAuditMission.FirstOrDefaultAsync(x => x.UserId.Equals(userId));

        if (result == null)
        {
            result = CurrentUsersAuditMission.Create(
                userId,
                auditMissionId
            ).Value;

           var add_result = await _context.CurrentUsersAuditMission.AddAsync(result);
            await _context.SaveChangesAsync();

            return Result<CurrentUsersAuditMission>.Success(result);
        }

        else
        {
            if (result != null) result.AuditMissionId = auditMissionId;

            _context.CurrentUsersAuditMission.Update(result);

            await _context.SaveChangesAsync();

            return Result<CurrentUsersAuditMission>.Success(result);
        }

        return Result<CurrentUsersAuditMission>.Failure("Failed to set the current user's audit mission.");
    }
}