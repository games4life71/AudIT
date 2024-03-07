using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudiT.Domain.Entities;

namespace AudIT.Infrastructure.Repositories;

public class ObjectiveRepository(AudITContext context) : BaseRepository<Objective>(context), IObjectiveRepository
{
    private readonly AudITContext _context = context;

}