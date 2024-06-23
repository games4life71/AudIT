using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudiT.Domain.Entities;
using AudIT.Domain.Misc;
using Microsoft.EntityFrameworkCore;

namespace AudIT.Infrastructure.Repositories;

public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
{
    private readonly AudITContext _context;

    public NotificationRepository(AudITContext context) : base(context)
    {
        _context = context;
    }


    public async Task<Result<List<Notification>>> GetByInstitutionId(Guid requestInstitutionId)
    {
        var notifications = await _context.Notifications
            .Where(n => n.InstitutionId == requestInstitutionId)
            .ToListAsync();

        if (notifications.Any())
            return Result<List<Notification>>.Success(notifications);

        return Result<List<Notification>>.Failure("No notifications found");
    }
}