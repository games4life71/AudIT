using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudiT.Domain.Entities;
using AudIT.Domain.Misc;
using Microsoft.EntityFrameworkCore;
using SkiaSharp.HarfBuzz;

namespace AudIT.Infrastructure.Repositories;

public class AuditMissionRecommendationRepository : BaseRepository<AuditMissionRecommendations>,
    IAuditMissionRecommendationsRepository
{
    public AuditMissionRecommendationRepository(AudITContext context) : base(context)
    {
        _context = context;
    }

    private readonly AudITContext _context;

    public async Task<Result<List<Recommendation>>> FindAllByAuditMissionIdAsync(Guid requestAuditMissionId)
    {
        var recommendations = await _context.AuditMissionRecommendations
            .Where(amr => amr.AuditMissionId == requestAuditMissionId)
            .Include(amr => amr.Recommendation)
            .ThenInclude(r => r.ObjectiveAction)
            .Select(amr => amr.Recommendation)

            .ToListAsync();


        if (recommendations.Count == 0)
        {
            return Result<List<Recommendation>>.Failure(
                $"Recommendations for AuditMission with id {requestAuditMissionId} not found.");
        }

        return Result<List<Recommendation>>.Success(recommendations);
    }
}