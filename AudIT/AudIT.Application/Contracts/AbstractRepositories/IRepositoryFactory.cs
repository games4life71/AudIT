using AudIT.Applicationa.Requests.Access.ReadAcces;
using AudIT.Domain.Misc;

namespace AudIT.Applicationa.Contracts.AbstractRepositories;



public interface IRepositoryFactory
{
    // public IRepositoryAcces<AuditableEntity> Create(string entityType);
    public IBaseAcces Create(string entityType);
    public (bool, Type) GetRepositoryType(string entityName);
    // public IRepositoryAcces<T> Create<T>(EntityType entityType) where T : AuditableEntity;
}