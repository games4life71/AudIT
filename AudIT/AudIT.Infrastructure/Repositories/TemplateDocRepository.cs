using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudiT.Domain.Entities;
using AudIT.Domain.Misc;

namespace AudIT.Infrastructure.Repositories;

public class TemplateDocRepository(AudITContext context)
    : BaseRepository<TemplateDocument>(context), ITemplateDocRepository
{
    private readonly AudITContext _context = context;

    public async Task<Result<TemplateDocument>> GetTemplateDocumentByName(string name)
    {
        var result = _dbcContext.TemplateDocuments
            .First(x => x.Name == name);


        if (result.Id == Guid.Empty)
        {
            return Result<TemplateDocument>.Failure("Document not found");
        }

        return Result<TemplateDocument>.Success(result);
    }
}