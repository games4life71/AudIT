using AudIT.Applicationa.Requests.User.Dto;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.User.Queries.GetInformation;

public class GetUserInformationQuery : IRequest<BaseDTOResponse<BaseUserInformationDto>>
{
    public string UserId { get; set; }

    public GetUserInformationQuery(string userId)
    {
        UserId = userId;
    }
}