using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudiT.Domain.Entities;
using AudIT.Domain.Misc;
using Microsoft.EntityFrameworkCore;

namespace AudIT.Infrastructure.Repositories;

public class AuditMissionRepository(AudITContext context)
    : BaseRepository<AuditMission>(context), IAuditMissionRepository

{
    private readonly AudITContext _context = context;

    public async Task<Result<IReadOnlyList<AuditMission>>> GetByOwnerId(string id)
    {
        try
        {
            var result = await _context.AuditMissions.Where(x => x.UserId == id).ToListAsync();

            if (result.Count == 0)
            {
                return Result<IReadOnlyList<AuditMission>>.Failure("No audit mission found for this user");
            }
            else
            {
                return Result<IReadOnlyList<AuditMission>>.Success(result);
            }
        }
        catch (Exception e)
        {
            return Result<IReadOnlyList<AuditMission>>.Failure(e.Message);
        }
    }

    public async Task<Result<IReadOnlyList<AuditMission>>> GetByDepartmentId(Guid requestDepartmentId)
    {
        try
        {
            var result = await _context.AuditMissions.Where(x => x.DepartmentId == requestDepartmentId).ToListAsync();

            if (result.Count == 0)
            {
                return Result<IReadOnlyList<AuditMission>>.Failure("No audit mission found for this department");
            }

            return Result<IReadOnlyList<AuditMission>>.Success(result);
        }
        catch (Exception e)
        {
            return Result<IReadOnlyList<AuditMission>>.Failure("Error: " + e.Message);
        }
    }

    public override async Task<Result<AuditMission>> FindByIdAsync(Guid id)
    {
        var result = await _context.AuditMissions
            .Where(a => a.Id == id)
            .Include(a => a.User)
            .Include(a=>a.Department)
            .FirstAsync();


        if (result == null)
        {
            return Result<AuditMission>.Failure("No audit mission found with this id");
        }

        return Result<AuditMission>.Success(result);
    }
}