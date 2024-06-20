using AudIT.Applicationa.Requests.User.Dto;
using AudIT.Applicationa.Responses;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AudIT.Applicationa.Requests.User.Commands.UpdateUserInfo;

public class UpdateUserInfoHandler(
    UserManager<AudiT.Domain.Entities.User> userManager,
    IMapper mapper
) : IRequestHandler<UpdateUserInfoCommand, BaseDTOResponse<BaseUserInformationDto>>
{
    public async Task<BaseDTOResponse<BaseUserInformationDto>> Handle(UpdateUserInfoCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var user = await userManager.FindByIdAsync(request.Id);

            if (user == null)
            {
                return new BaseDTOResponse<BaseUserInformationDto>
                {
                    Message = $"User with id {request.Id} not found",
                    Success = false
                };
            }

            user.UpdateUserInfo(
                request.SecondEmail,
                request.Adress,
                request.PhoneNumber,
                request.OfficePhoneNumber,
                request.Functie,
                request.Username
            );

            var result = await userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return new BaseDTOResponse<BaseUserInformationDto>("Failed to update user information", false);
            }

            return new BaseDTOResponse<BaseUserInformationDto>(mapper.Map<BaseUserInformationDto>(user));
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseUserInformationDto>(e.Message, false);
        }
    }
}