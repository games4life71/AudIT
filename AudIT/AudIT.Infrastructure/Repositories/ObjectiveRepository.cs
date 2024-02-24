using AudiT.Domain.Entities;

namespace AudIT.Infrastructure.Repositories;

public class ObjectiveRepository(AudITContext context) : BaseRepository<Objective>(context)
{
    private readonly AudITContext _context = context;
}