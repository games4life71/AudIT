using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudIT.Applicationa.Requests.Notification.DTO;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;

namespace AudIT.Applicationa.Requests.Notification.Queries.GetByInstitution;

public class GetNotificationsByInstitutionIdHandler(
    INotificationRepository notificationRepository,
    IMapper mapper
) : IRequestHandler<GetNotificationsByInstitutionIdQuery, BaseDTOResponse<NotificationWithDateDto>>
{
    public async Task<BaseDTOResponse<NotificationWithDateDto>> Handle(GetNotificationsByInstitutionIdQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var notifications = await notificationRepository.GetByInstitutionId(request.InstitutionId);

            if (!notifications.IsSuccess)
            {
                return new BaseDTOResponse<NotificationWithDateDto>("No notifications found", false);
            }

            var notificationsDto = mapper.Map<List<NotificationWithDateDto>>(notifications.Value);


            return new BaseDTOResponse<NotificationWithDateDto>(notificationsDto, "Notifications found", true);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<NotificationWithDateDto>(e.Message, false);
        }
    }
}