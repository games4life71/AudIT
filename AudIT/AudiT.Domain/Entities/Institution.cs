using AudIT.Domain.Misc;

namespace AudiT.Domain.Entities;



/// <summary>
/// A class that models an institution
///
/// </summary>
public class Institution:AuditableEntity
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Address { get; private set; }

    public string HomePhoneNumber { get;private set; }

    public List<Department> Departments { get; private set; } = new List<Department>();

    private Institution( string name, string address, string homePhoneNumber)
    {
        Id = new Guid();
        Name = name;
        Address = address;
        HomePhoneNumber = homePhoneNumber;
    }

    public Institution()
    {

    }

    public static  Result<Institution> Create(string name, string address, string homePhoneNumber)
    {

        if (String.IsNullOrEmpty(name))
        {
            return Result<Institution>.Failure("Name of institution cannot be null or empty ! ");
        }

        if (String.IsNullOrEmpty(address))
        {
            return Result<Institution>.Failure("Address of institution cannot be null or empty !");
        }

        if (String.IsNullOrEmpty(homePhoneNumber))
        {
            return Result<Institution>.Failure("Phone number  of institution cannot be null or empty !");
        }


        return Result<Institution>.Success(new Institution(name, address, homePhoneNumber));

    }

}