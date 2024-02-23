using AudiT.Domain.Entities;

namespace AudIT.Infrastructure.Repositories;

public class AudMissDocRepository(AudITContext context) : BaseRepository<AuditMissionDocument>(context)
{
    private readonly AudITContext _context = context;
}
