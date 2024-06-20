using Frontend.EntityDtos.Misc;
using Frontend.EntityDtos.User;
using Frontend.EntityViewModels.User;

namespace Frontend.Contracts.Abstract_Services.UserService;

public interface IUserService
{
    public const string BaseUrl = "https://localhost:7248/api/v1/Authentification";

    public Task<BaseDTOResponse<BaseUserViewModel>> GetUserInformationAsync();

    public Task<BaseDTOResponse<BaseUserViewModel>> UpdateUserInfoAsync(UpdateUserInfoDto updateUserInfoDto);

}