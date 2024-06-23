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

    public async Task<(string, bool)> DeleteByRecommendationId(Guid requestId)
    {
        var auditMissionRecommendation = await _context.AuditMissionRecommendations
            .Where(amr => amr.RecommendationId == requestId)
            .FirstOrDefaultAsync();

        if (auditMissionRecommendation == null)
        {
            return ("Recommendation not found", false);
        }

        _context.AuditMissionRecommendations.Remove(auditMissionRecommendation);

        await _context.SaveChangesAsync();

        return ("Recommendation deleted successfully", true);
    }

    public Task<Result<List<Recommendation>>> GetRecommendationsByInstitutionId(Guid valueInstitutionId)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<AuditMissionRecommendations>> GetAuditMissionByRecommendationId(Guid recommendationId)
    {
        var auditMission = _context.AuditMissionRecommendations
            .Where(amr => amr.RecommendationId == recommendationId)
            .Include(amr => amr.AuditMission)
            .Include(amr=>amr.Recommendation)
            .FirstOrDefault();

        if (auditMission == null)
            return Result<AuditMissionRecommendations>.Failure("AuditMission not found");

        return Result<AuditMissionRecommendations>.Success(auditMission);
    }
}