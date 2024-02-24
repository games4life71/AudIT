using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudiT.Domain.Entities;

namespace AudIT.Infrastructure.Repositories;

public class AuditMissionRepository(AudITContext context)
    : BaseRepository<AuditMission>(context), IAuditMissionRepository

{
    private readonly AudITContext _context = context;
}