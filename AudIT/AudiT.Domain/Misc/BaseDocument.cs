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

    public string Name { get; protected set; }

    public string Extension { get; protected set; }

    public User Owner { get; private set; }

    public string OwnerId { get; private set; }

    public DocumentType DocumentType { get; private set; }

    protected BaseDocument(string name , string extension , DocumentType type, User owner , Guid ownerId)
    {
        DocumentType = type;
        Id = new Guid();
        Name = name;
        Extension = extension;
        Owner = owner;
        OwnerId = ownerId.ToString();
    }

    public BaseDocument()
    {

    }

}

public enum DocumentType
{
    Standalone,
    Template
}