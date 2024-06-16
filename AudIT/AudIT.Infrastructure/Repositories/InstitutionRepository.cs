using AudiT.Domain.Entities;
using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Domain.Misc;
using Microsoft.EntityFrameworkCore;

namespace AudIT.Infrastructure.Repositories;

public class InstitutionRepository(AudITContext context) : BaseRepository<Institution>(context), IInstitutionRepository
{
    private readonly AudITContext _context = context;

    public Task<Result<Institution>> FindInstitutionByDomainAsync(string domain)
    {
        var institution = _context.Institutions.Where(i => i.EmailDomains.Contains(domain))
            .Include(i => i.InstitutionAdmin).FirstOrDefault();

        if (institution == null)
        {
            return Task.FromResult(Result<Institution>.Failure($"Institution with domain {domain} not found."));
        }

        return Task.FromResult(Result<Institution>.Success(institution));
    }

    public async Task<Result<List<Institution>>> GetAllInstitutionsFullAsync()
    {
        var institutions = _context.Institutions.Include(i => i.Departments).ToList();

        if (!institutions.Any())
        {
            return Result<List<Institution>>.Failure("No institutions found.");
        }

        return Result<List<Institution>>.Success(institutions);
    }
}