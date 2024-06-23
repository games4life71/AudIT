using AudiT.Domain.Entities;
using AudIT.Domain.Misc;

namespace AudIT.Applicationa.Contracts.AbstractRepositories;

public interface INotificationRepository:IRepository<Notification>
{
    public  Task<Result<List<Notification>>> GetByInstitutionId(Guid requestInstitutionId);
}