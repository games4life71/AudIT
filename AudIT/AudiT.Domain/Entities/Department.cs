using AudIT.Domain.Misc;

namespace AudiT.Domain.Entities;

/// <summary>
/// A class that models the Departament using in communication;
/// Modification don't need to make so often
/// Each Department is bound to an institution
/// </summary>
public class Department:AuditableEntity
{

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Address { get; private set; }

    public string HomePhoneNumber { get;private set; }

    public Institution Institution { get; private set; }
    private Department( string name, string address, string homePhoneNumber,Institution institution)
    {
        Id = new Guid();
        Name = name;
        Address = address;
        HomePhoneNumber = homePhoneNumber;
        Institution = institution;
    }

    public Department()
    {

    }

    public static Result<Department> Create(string name, string address, string homePhoneNumber,Institution institution)
    {

        //TODO make all the checks

        if (String.IsNullOrEmpty(name))
        {
            return Result<Department>.Failure("Name of depart cannot be null or empty ! ");
        }

        if (String.IsNullOrEmpty(address))
        {
            return Result<Department>.Failure("Address of depart cannot be null or empty !");
        }

        if (String.IsNullOrEmpty(homePhoneNumber))
        {
            return Result<Department>.Failure("Phone number  of depart cannot be null or empty !");
        }

        return Result<Department>.Success(new Department(name, address, homePhoneNumber,institution));

    }

}