using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudiT.Domain.Entities;
using AudIT.Domain.Misc;
using Microsoft.EntityFrameworkCore;

namespace AudIT.Infrastructure.Repositories;

public class RecommendationDocumentRepository : BaseRepository<RecommendationDocument>,
    IRecommendationDocumentRepository
{
    private readonly AudITContext _context;

    public RecommendationDocumentRepository(AudITContext context) : base(context)
    {
        _context = context;
    }


    public async Task<Result<List<RecommendationDocument>>> FindByRecommendationId(Guid recommendationId)
    {
        var recommendationDocuments =
            await _context.RecommendationDocuments
                .Where(x => x.RecommendationId == recommendationId)
                .ToListAsync();

        if (recommendationDocuments.Any())
        {
            return Result<List<RecommendationDocument>>.Success(recommendationDocuments);
        }

        return Result<List<RecommendationDocument>>.Failure("No recommendation documents found");
    }
}