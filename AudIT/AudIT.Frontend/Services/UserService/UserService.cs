using System.Net.Http.Json;
using Frontend.Contracts.Abstract_Services.UserService;
using Frontend.EntityDtos.Misc;
using Frontend.EntityDtos.User;
using Frontend.EntityViewModels.User;
using Newtonsoft.Json;

namespace Frontend.Services.UserService;

public class UserService(HttpClient httpClient) : IUserService
{
    public async Task<BaseDTOResponse<BaseUserViewModel>> GetUserInformationAsync()
    {
        var response = await httpClient.GetAsync($"{IUserService.BaseUrl}/get-user-information");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseUserViewModel>>(content);
            if (result != null) return result;
        }
        else
        {
            return new BaseDTOResponse<BaseUserViewModel>
            {
                Success = false,
                Message = "An error occurred while fetching user information"
            };
        }

        return new BaseDTOResponse<BaseUserViewModel>
        {
            Success = false,
            Message = "An error occurred while fetching user information"
        };
    }

    public async Task<BaseDTOResponse<BaseUserViewModel>> UpdateUserInfoAsync(UpdateUserInfoDto updateUserInfoDto)
    {
        var response =
            await httpClient.PatchAsJsonAsync($"{IUserService.BaseUrl}/update-user-information", updateUserInfoDto);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseUserViewModel>>(content);
            if (result != null) return result;
        }
        else
        {
            return new BaseDTOResponse<BaseUserViewModel>
            {
                Success = false,
                Message = "An error occurred while updating user information"
            };
        }

        return new BaseDTOResponse<BaseUserViewModel>
        {
            Success = false,
            Message = "An error occurred while updating user information"
        };
    }

    public async Task<BaseDTOResponse<UserWithIdViewModel>> GetAllUsersByInstitutionIdAsync(Guid institutionId)
    {
        var response =
            await httpClient.GetAsync(
                $"{IUserService.BaseUrl}/get-all-users-by-institution-id/{institutionId}/{institutionId}");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BaseDTOResponse<UserWithIdViewModel>>(content);
            if (result != null) return result;
        }
        else
        {
            return new BaseDTOResponse<UserWithIdViewModel>
            {
                Success = false,
                Message = "An error occurred while fetching users"
            };
        }

        return new BaseDTOResponse<UserWithIdViewModel>
        {
            Success = false,
            Message = "An error occurred while fetching users"
        };
    }
}