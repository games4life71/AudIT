using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudiT.Domain.Entities;
using AudIT.Domain.Misc;

namespace AudIT.Infrastructure.Repositories;

public class ActionRiskRepository:BaseRepository<ActionRisk>, IActionRiskRepository
{
    public ActionRiskRepository(AudITContext context) : base(context)
    {

    }


}