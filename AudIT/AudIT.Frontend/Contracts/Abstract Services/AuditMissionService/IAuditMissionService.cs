using Frontend.EntityDtos.AuditMission;
using Frontend.EntityDtos.Misc;

namespace Frontend.Contracts.Abstract_Services.AuditMissionService;

public interface IAuditMissionService
{
    public const string ApiPath = "http://localhost:5071/api/v1/AuditMission";
    public Task<BaseDTOResponse<BaseAuditMissionDto>> GetAuditMissionById(Guid id);

    public Task<BaseDTOResponse<BaseAuditMissionDto>> GetAuditMissionByOwnerId(Guid ownerId);

    public Task<BaseDTOResponse<BaseAuditMissionDto>> GetAuditMissionByDepartmentId(Guid departmentId);

    public Task<BaseDTOResponse<BaseAuditMissionDto>> CreateAuditMissionAsync(CreateAuditMissionDto createAuditMissionDto);
}