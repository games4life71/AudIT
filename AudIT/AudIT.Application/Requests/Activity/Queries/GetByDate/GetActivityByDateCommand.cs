using AudIT.Applicationa.Requests.Activity.DTO;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Activity.Queries.GetByDate;

public class GetActivityByDateCommand : IRequest<BaseDTOResponse<ActivityWIthDocumentsDto>>
{
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public GetActivityByDateCommand(DateTime startDate, DateTime endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
    }
}