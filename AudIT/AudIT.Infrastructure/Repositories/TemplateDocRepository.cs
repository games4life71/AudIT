using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudiT.Domain.Entities;

namespace AudIT.Infrastructure.Repositories;

public class TemplateDocRepository(AudITContext context):BaseRepository<TemplateDocument>(context), ITemplateDocRepository
{
    private readonly AudITContext _context = context;
}