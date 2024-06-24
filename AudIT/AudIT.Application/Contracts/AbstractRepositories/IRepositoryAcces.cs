using AudIT.Domain.Misc;

namespace AudIT.Applicationa.Contracts.AbstractRepositories;

public interface IBaseAcces
{

}


public interface IRepositoryAcces<T> : IBaseAcces  where T : class
{
    Task<Result<T>> SetWriteAccesAsync(Guid auserId, Guid entityId);
    Task<Result<T>> SetReadAccesAsync(Guid userId, Guid entityId);
}