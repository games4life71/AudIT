using System.Net.Http.Json;
using Frontend.Contracts.Abstract_Services.AuditMissionService;
using Frontend.EntityDtos.AuditMission;
using Frontend.EntityDtos.Misc;
using Newtonsoft.Json;

namespace Frontend.Services.AuditMission;

public class AuditMissionService(HttpClient httpClient) : IAuditMissionService
{
    public async Task<BaseDTOResponse<BaseAuditMissionDto>> GetAuditMissionById(Guid id)
    {
        try
        {
            var response = await httpClient.GetAsync($"{IAuditMissionService.ApiPath}/get-audit-mission/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return new BaseDTOResponse<BaseAuditMissionDto>();
            }

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseAuditMissionDto>>(content);

            if (result is { Success: true, DtoResponse: not null })
            {
                return new BaseDTOResponse<BaseAuditMissionDto>(result.DtoResponse);
            }
            else
            {
                return new BaseDTOResponse<BaseAuditMissionDto>();
            }
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseAuditMissionDto>
            {
                Success = false,
                Message = e.Message
            };
        }
    }

    public async Task<BaseDTOResponse<BaseAuditMissionDto>> GetAuditMissionByOwnerId()
    {
        try
        {
            var response =
                await httpClient.GetAsync($"{IAuditMissionService.ApiPath}/get-audit-mission-by-owner");
            if (!response.IsSuccessStatusCode)
            {
                return new BaseDTOResponse<BaseAuditMissionDto>();
            }

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseAuditMissionDto>>(content);

            if (result != null && result.Success && result.DtoResponses.Count > 0)
            {
                return result;
            }
            else
            {
                return new BaseDTOResponse<BaseAuditMissionDto>("An error occurred " + result.Message, false);
            }
        }
        catch (Exception e)
        {
            return new BaseDTOResponse<BaseAuditMissionDto>
            {
                Success = false,
                Message = e.Message
            };
        }
    }

    public async Task<BaseDTOResponse<BaseAuditMissionDto>> GetAuditMissionByDepartmentId(Guid departmentId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseDTOResponse<BaseAuditMissionDto>> CreateAuditMissionAsync(
        CreateAuditMissionDto createAuditMissionDto)
    {
        var response = await httpClient.PostAsJsonAsync($"{IAuditMissionService.ApiPath}/add-audit-mission",
            createAuditMissionDto);

        if (!response.IsSuccessStatusCode)
        {
            return new BaseDTOResponse<BaseAuditMissionDto>("Faile to create audit mission", false);
        }

        var content = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseAuditMissionDto>>(content);
        if (result is { Success: true, DtoResponse: not null })
        {
            return new BaseDTOResponse<BaseAuditMissionDto>(result.DtoResponse);
        }

        return new BaseDTOResponse<BaseAuditMissionDto>("Audit mission failed", false);
    }

    public async Task<BaseDTOResponse<BaseAuditMissionDto>> UpdateAuditMissionAsync(
        UpdateAuditMissionDto updateAuditMissionDto)
    {
        var response = await httpClient.PutAsJsonAsync($"{IAuditMissionService.ApiPath}/update-audit-mission",
            updateAuditMissionDto);

        if (!response.IsSuccessStatusCode)
        {
            return new BaseDTOResponse<BaseAuditMissionDto>("Failed to update audit mission", false);
        }

        return new BaseDTOResponse<BaseAuditMissionDto>("Audit mission updated successfully", true);
    }

    public async Task<BaseDTOResponse<BaseAuditMissionDto>> GetAuditMissionsByUserInstitution()
    {
        var response =
            await httpClient.GetAsync($"{IAuditMissionService.ApiPath}/get-audit-mission-by-user-institution");


        if (!response.IsSuccessStatusCode)
        {
            return new BaseDTOResponse<BaseAuditMissionDto>("Failed to get audit mission by user institution", false);
        }

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseAuditMissionDto>>(content);

        if (result != null && result.Success && result.DtoResponses.Count > 0)
        {
            return result;
        }
        else
        {
            return new BaseDTOResponse<BaseAuditMissionDto>("An error occurred " + result.Message, false);
        }
    }

    public async Task<BaseDTOResponse<BaseAuditMissionDto>> GetAuditMissionByRecommendation(Guid recommendationId)
    {
        var response =
            await httpClient.GetAsync(
                $"{IAuditMissionService.ApiPath}/get-mission-by-recommendation/{recommendationId}");

        if (!response.IsSuccessStatusCode)
        {
            return new BaseDTOResponse<BaseAuditMissionDto>("Failed to get audit mission by recommendation", false);
        }

        var content = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<BaseDTOResponse<BaseAuditMissionDto>>(content);

        if (result is { Success: true, DtoResponse: not null })
        {
            return new BaseDTOResponse<BaseAuditMissionDto>(result.DtoResponse);
        }

        return new BaseDTOResponse<BaseAuditMissionDto>("Failed to get audit mission by recommendation", false);
    }
}