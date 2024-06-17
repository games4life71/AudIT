using System.Net.Http.Json;
using Frontend.Contracts.Abstract_Services.DepartmentService;
using Frontend.EntityDtos.Department;
using Frontend.EntityDtos.Misc;
using Newtonsoft.Json;
using JsonSerializerOptions = System.Text.Json.JsonSerializerOptions;

namespace Frontend.Services.Department;

public class DepartmentService(HttpClient httpClient) : IDepartmentService
{
    public async Task<BaseDTOResponse<BaseDepartmentDto>> GetDepartmentByIdAsync(Guid id)
    {
        try
        {
            var response = await httpClient.GetAsync($"{IDepartmentService.ApiPath}/get-department/{id}");
            if (!response.IsSuccessStatusCode)
                return new BaseDTOResponse<BaseDepartmentDto>
                {
                    Success = false,
                    Message = response.ReasonPhrase
                };

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseDepartmentDto>>(content);

            if (result is { Success: true, DtoResponse: not null })
            {
                return new BaseDTOResponse<BaseDepartmentDto>(result.DtoResponse);
            }
            else
            {
                return new BaseDTOResponse<BaseDepartmentDto>();
            }
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseDepartmentDto>
            {
                Success = false,
                Message = e.Message
            };
        }
    }

    public async Task<BaseDTOResponse<BaseDepartmentDto>> GetDepartmentsByInstitutionIdAsync(Guid id)
    {
        try
        {
            var response =
                await httpClient.GetAsync($"{IDepartmentService.ApiPath}/get-departments-by-institution-id/{id}");
            if (!response.IsSuccessStatusCode)
                return new BaseDTOResponse<BaseDepartmentDto>
                {
                    Success = false,
                    Message = "Failed to get departments by institution id."
                };

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseDepartmentDto>>(content);

            if (result is { Success: true, DtoResponses: not null })
            {
                return result;
            }
            else
            {
                return new BaseDTOResponse<BaseDepartmentDto>();
            }
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseDepartmentDto>
            {
                Success = false,
                Message = e.Message
            };
        }
    }

    public async Task<BaseDTOResponse<BaseDepartmentDto>> CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto)
    {
        var response =
            await httpClient.PostAsJsonAsync($"{IDepartmentService.ApiPath}/create-department", createDepartmentDto);


        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseDepartmentDto>>(content);

            if (result is { Success: true, DtoResponse: not null })
            {
                return new BaseDTOResponse<BaseDepartmentDto>(result.DtoResponse);
            }
        }

        return new BaseDTOResponse<BaseDepartmentDto>
        {
            Success = false,
            Message = response.ReasonPhrase
        };
    }

    public async Task<BaseDTOResponse<BaseResponse>> DeleteDepartmentAsync(Guid id)
    {
        var response = await httpClient.DeleteAsync($"{IDepartmentService.ApiPath}/delete-department/{id}");

        if (response.IsSuccessStatusCode)
        {
            return new BaseDTOResponse<BaseResponse>("Department deleted successfully.", true);
        }

        return new BaseDTOResponse<BaseResponse>
        {
            Success = false,
            Message = response.ReasonPhrase
        };
    }

    public async Task<BaseDTOResponse<BaseDepartmentDto>> UpdateDepartmentAsync(UpdateDepartmentDto updateDepartmentDto)
    {
        var response =
            await httpClient.PutAsJsonAsync($"{IDepartmentService.ApiPath}/update-department", updateDepartmentDto);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseDepartmentDto>>(content);

            if (result is { Success: true, DtoResponse: not null })
            {
                return new BaseDTOResponse<BaseDepartmentDto>(result.DtoResponse);
            }
        }

        return new BaseDTOResponse<BaseDepartmentDto>
        {
            Success = false,
            Message = response.ReasonPhrase
        };
    }
}