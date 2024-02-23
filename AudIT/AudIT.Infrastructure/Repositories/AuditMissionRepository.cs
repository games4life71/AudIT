using AudiT.Domain.Entities;

namespace AudIT.Infrastructure.Repositories;

public class AuditMissionRepository(AudITContext context) : BaseRepository<AuditMission>(context)
{
    private readonly AudITContext _context = context;
}