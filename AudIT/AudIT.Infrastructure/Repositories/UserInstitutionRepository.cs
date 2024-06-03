using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudiT.Domain.Entities;
using AudIT.Domain.Misc;
using Microsoft.EntityFrameworkCore;

namespace AudIT.Infrastructure.Repositories;

public class UserInstitutionRepository(AudITContext context)
    : BaseRepository<UserInstitution>(context), IUserInstitutionRepository
{
    private readonly AudITContext _context = context;


    public async Task<Result<List<User>>> GetAllUsersByInstitutionId(Guid institutionId)
    {
        var results = await _context.UserInstitution
            .Where(x => x.InstitutionId == institutionId)
            .Include(a => a.User)
            .Select(x => x.User)
            .ToListAsync();


        if (results.Count == 0)
            return Result<List<User>>.Failure("No users found for this institution");

        return Result<List<User>>.Success(results);
    }
}