using AudiT.Domain.Entities;

namespace AudIT.Infrastructure.Repositories;

public class TemplateDocRepository(AudITContext context):BaseRepository<TemplateDocument>(context)
{
    private readonly AudITContext _context = context;
}