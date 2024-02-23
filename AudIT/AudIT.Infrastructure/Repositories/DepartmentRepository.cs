using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudiT.Domain.Entities;

namespace AudIT.Infrastructure.Repositories;

public class DepartmentRepository(AudITContext context) : BaseRepository<Department>(context), IDepartmentRepository
{
    private readonly AudITContext _context = context;
}