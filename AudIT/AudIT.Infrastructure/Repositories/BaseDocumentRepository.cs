using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Domain.Misc;

namespace AudIT.Infrastructure.Repositories;

public class BaseDocumentRepository : BaseRepository<BaseDocument>, IBaseDocumentRepository
{
    public BaseDocumentRepository(AudITContext context) : base(context)
    {

    }
}