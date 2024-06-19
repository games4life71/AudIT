using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudiT.Domain.Entities;
using AudIT.Domain.Misc;
using Microsoft.EntityFrameworkCore;

namespace AudIT.Infrastructure.Repositories;

public class TemplateDocRepository(AudITContext context)
    : BaseRepository<TemplateDocument>(context), ITemplateDocRepository
{
    private readonly AudITContext _context = context;

    public async Task<Result<TemplateDocument>> GetTemplateDocumentByName(string name)
    {
        var result = await _dbcContext.TemplateDocuments
            .FirstOrDefaultAsync(x => x.Name == name);

        if (result == null)
        {
            return Result<TemplateDocument>.Failure("Document not found");
        }

        if (result.Id == Guid.Empty)
        {
            return Result<TemplateDocument>.Failure("Document not found");
        }

        return Result<TemplateDocument>.Success(result);
    }
}