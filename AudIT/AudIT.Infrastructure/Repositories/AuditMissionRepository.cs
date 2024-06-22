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
            var result = await _context.AuditMissions
                .Where(x => x.UserId == id)
                // .Include(x=>x.LastModifiedBy)
                .ToListAsync();

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
            var result = await _context.AuditMissions
                .Where(x => x.DepartmentId == requestDepartmentId).ToListAsync();

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

    public async Task<Result<IReadOnlyList<AuditMission>>> GetByInstitutionId(Guid requestInstitutionId)
    {
        var auditMissions = await _context.AuditMissions
            .Where(x => x.Department.Institution.Id == requestInstitutionId)
            .ToListAsync();

        if (!auditMissions.Any())
        {
            return Result<IReadOnlyList<AuditMission>>.Failure("No audit mission found for this institution");
        }

        return Result<IReadOnlyList<AuditMission>>.Success(auditMissions);
    }

    public override async Task<Result<AuditMission>> FindByIdAsync(Guid id)
    {
        var result = await _context.AuditMissions
            .Where(a => a.Id == id)
            .Include(a => a.User)
            .Include(a => a.Department)
            .FirstAsync();


        if (result == null)
        {
            return Result<AuditMission>.Failure("No audit mission found with this id");
        }

        return Result<AuditMission>.Success(result);
    }

    // public override async Task<Result<AuditMission>> UpdateAsync(AuditMission entity)
    // {
    //     var result = await _context.AuditMissions.FindAsync(entity.Id);
    //
    //
    //     if (result == null)
    //     {
    //         return Result<AuditMission>.Failure("No audit mission found with this id");
    //     }
    //
    //
    //     //update the entity
    //
    //     result.Update(
    //         name: entity.Name,
    //         department: entity.Department,
    //         departmentId: entity.DepartmentId
    //     );
    //
    //
    //     _context.AuditMissions.Update(result);
    //
    //     await _context.SaveChangesAsync();
    //
    //     return Result<AuditMission>.Success(result);
    // }
}