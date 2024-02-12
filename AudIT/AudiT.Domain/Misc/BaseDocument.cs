using AudiT.Domain.Entities;

namespace AudIT.Domain.Misc;
using AudIT.Domain;
/// <summary>
/// This class models the base of a document that is stored in the database/storage system
/// It contains the properties that are common to all documents
/// </summary>
public class BaseDocument:AuditableEntity
{

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Extension { get; private set; }

    public User Owner { get; private set; }

    public Guid OwnerId { get; private set; }



    protected BaseDocument(string name , string extension , User owner , Guid ownerId)
    {
        Id = new Guid();
        Name = name;
        Extension = extension;
        Owner = owner;
        OwnerId = ownerId;
    }

    public BaseDocument()
    {

    }

}