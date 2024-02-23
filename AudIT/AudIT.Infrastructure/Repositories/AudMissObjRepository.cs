using AudiT.Domain.Entities;

namespace AudIT.Infrastructure.Repositories;

public class AudMissObjRepository(AudITContext context) : BaseRepository<AuditMissionObjectives>(context)
{
    private readonly AudITContext _context = context;
}