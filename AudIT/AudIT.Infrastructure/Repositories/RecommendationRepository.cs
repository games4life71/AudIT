using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudiT.Domain.Entities;
using AudIT.Domain.Misc;
using Microsoft.EntityFrameworkCore;

namespace AudIT.Infrastructure.Repositories;

public class RecommendationRepository(AudITContext context)
    : BaseRepository<Recommendation>(context), IRecommendationRepository
{
    public async Task<Result<Recommendation>> FindByIdWithObjectiveActionAsync(Guid id)
    {
        try
        {
            var result = await context.Recommendations
                .Include(x => x.ObjectiveAction)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
            {
                return Result<Recommendation>.Failure("No recommendation found with this id");
            }

            return Result<Recommendation>.Success(result);
        }
        catch (Exception e)
        {
            return Result<Recommendation>.Failure(e.Message);
        }
    }

    public async Task<Result<Recommendation>> UpdateStatusAsync(Guid id, Status newStatus)
    {
        try
        {
            var recommendation = context.Recommendations.FirstOrDefault(x => x.Id == id);

            if (recommendation == null)
            {
                return Result<Recommendation>.Failure("No recommendation found with this id");
            }

            recommendation.SetStatus(newStatus);

            var result = await context.SaveChangesAsync();

            if (!result.Equals(1))
                return Result<Recommendation>.Failure("Failed to update recommendation status");

            return Result<Recommendation>.Success(recommendation);
        }
        catch (Exception e)
        {
            return Result<Recommendation>.Failure(e.Message);
        }
    }
}