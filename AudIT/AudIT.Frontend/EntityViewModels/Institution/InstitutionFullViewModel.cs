using Frontend.EntityDtos.Department;
using Frontend.EntityDtos.Institution;

namespace Frontend.EntityViewModels.Institution;

public class InstitutionFullViewModel : BaseInstitutionDto
{
    public string HomePhoneNumber { get; set; }

    public List<BaseDepartmentDto> Departments { get; set; }


    public InstitutionFullViewModel(Guid id, string name, string address, string homePhoneNumber,
        List<BaseDepartmentDto> departments) : base(id, name, address)
    {
        HomePhoneNumber = homePhoneNumber;
        Departments = departments;
    }
}