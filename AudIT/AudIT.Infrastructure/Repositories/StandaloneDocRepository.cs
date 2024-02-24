using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudiT.Domain.Entities;

namespace AudIT.Infrastructure.Repositories;

public class StandaloneDocRepository(AudITContext context):BaseRepository<StandaloneDocument>(context), IStandaloneDocRepository
{
    private readonly AudITContext _context = context;
}