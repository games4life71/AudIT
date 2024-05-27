using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudiT.Domain.Entities;
using AudIT.Domain.Misc;
using Microsoft.EntityFrameworkCore;

namespace AudIT.Infrastructure.Repositories;

public class DepartmentRepository(AudITContext context) : BaseRepository<Department>(context), IDepartmentRepository
{
    private readonly AudITContext _context = context;

    public override async Task<Result<Department>> FindByIdAsync(Guid id)
    {
        var department = await context.Departments
            .Where(x => x.Id == id)
            .Include(x => x.Institution)
            .FirstOrDefaultAsync();

        if (department == null)
            return Result<Department>.Failure("Department not found");

        return Result<Department>.Success(department);
    }

    public async Task<Result<Department>> FindByInstitutionIdAsync(Guid institutionId)
    {
        var department = await context.Departments
            .Where(x => x.Institution.Id == institutionId)
            .Include(x => x.Institution)
            .FirstOrDefaultAsync();

        if (department == null)
            return Result<Department>.Failure("Department not found");

        return Result<Department>.Success(department);
    }
}