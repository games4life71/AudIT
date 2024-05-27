using Frontend.Contracts.Abstract_Services.AuditMissionService;
using Frontend.EntityDtos.AuditMission;
using Frontend.EntityDtos.Misc;
using Newtonsoft.Json;

namespace Frontend.Services.AuditMission;

public class AuditMissionService(HttpClient httpClient): IAuditMissionService
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

    public async Task<BaseDTOResponse<BaseAuditMissionDto>> GetAuditMissionByOwnerId(Guid ownerId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseDTOResponse<BaseAuditMissionDto>> GetAuditMissionByDepartmentId(Guid departmentId)
    {
        throw new NotImplementedException();
    }
}