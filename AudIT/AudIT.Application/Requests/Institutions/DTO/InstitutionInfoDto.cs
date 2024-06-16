using AudIT.Applicationa.Requests.Department.Dto;

namespace AudIT.Applicationa.Requests.Institution.DTO;

public class InstitutionInfoDto : BaseInstitutionDto
{
    public string HomePhoneNumber { get; set; }

    public List<BaseDepartmentDto> Departments { get; set; }

    public InstitutionInfoDto(Guid id, string name, string address, string homePhoneNumber,
        List<BaseDepartmentDto> departments) : base(id, name, address)
    {
        HomePhoneNumber = homePhoneNumber;
        Departments = departments;
    }
}