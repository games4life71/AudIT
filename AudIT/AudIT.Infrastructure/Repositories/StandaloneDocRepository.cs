using AudiT.Domain.Entities;

namespace AudIT.Infrastructure.Repositories;

public class StandaloneDocRepository(AudITContext context):BaseRepository<StandaloneDocument>(context)
{
    private readonly AudITContext _context = context;
}