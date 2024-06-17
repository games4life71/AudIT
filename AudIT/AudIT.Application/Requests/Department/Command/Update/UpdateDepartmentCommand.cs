using AudIT.Applicationa.Requests.Department.Dto;
using AudIT.Applicationa.Responses;
using MediatR;

namespace AudIT.Applicationa.Requests.Department.Command.Update;

public class UpdateDepartmentCommand:IRequest<BaseDTOResponse<BaseDepartmentDto>>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Adress { get; set; }

    public string PhoneNumber { get; set; }

    public UpdateDepartmentCommand(Guid id, string name, string adress, string phoneNumber)
    {
        Id = id;
        Name = name;
        Adress = adress;
        PhoneNumber = phoneNumber;
    }
}