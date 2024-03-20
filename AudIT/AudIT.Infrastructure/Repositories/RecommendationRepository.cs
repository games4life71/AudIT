using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudiT.Domain.Entities;

namespace AudIT.Infrastructure.Repositories;

public class RecommendationRepository(AudITContext context)
    : BaseRepository<Recommendation>(context), IRecommendationRepository
{



}