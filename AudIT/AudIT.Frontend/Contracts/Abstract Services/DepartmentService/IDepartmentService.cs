using Frontend.EntityDtos.Department;
using Frontend.EntityDtos.Misc;

namespace Frontend.Contracts.Abstract_Services.DepartmentService;

public interface IDepartmentService
{
    public const string ApiPath = "https://localhost:7248/api/v1/Department";

    public Task<BaseDTOResponse<BaseDepartmentDto>> GetDepartmentByIdAsync(Guid id);

    public Task<BaseDTOResponse<BaseDepartmentDto>> GetDepartmentsByInstitutionIdAsync(Guid id);

    public Task<BaseDTOResponse<BaseDepartmentDto>> CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto);

    public Task<BaseDTOResponse<BaseResponse>> DeleteDepartmentAsync(Guid id);

    public Task<BaseDTOResponse<BaseDepartmentDto>> UpdateDepartmentAsync(UpdateDepartmentDto updateDepartmentDto);
}