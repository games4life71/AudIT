using AudIT.Applicationa.Requests.User.Dto;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AudIT.Applicationa.Requests.User.Queries.GetInformation;

public class GetUserInformationHandler(
    UserManager<AudiT.Domain.Entities.User> userManager,
    IMapper mapper
) : IRequestHandler<GetUserInformationQuery, BaseDTOResponse<BaseUserInformationDto>>
{
    public async Task<BaseDTOResponse<BaseUserInformationDto>> Handle(GetUserInformationQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var user = await userManager.FindByIdAsync(request.UserId);

            if (user == null)
            {
                return new BaseDTOResponse<BaseUserInformationDto>
                {
                    Success = false,
                    Message = $"User with id {request.UserId} not found"
                };
            }

            var userDto = mapper.Map<BaseUserInformationDto>(user);

            return new BaseDTOResponse<BaseUserInformationDto>(userDto);
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseUserInformationDto>
            {
                Success = false,
                Message = e.Message
            };
        }
    }
}