using AudIT.Domain.Misc;

namespace AudiT.Domain.Entities;

public class TemplateDocument:BaseDocument
{

    //the state of which the document is in : Draft, Published, Archived etc
    public DocumentState State { get; private set; }

    public TemplateType Type { get; private set; }

    public int Version { get; private set; }


    public TemplateDocument()
    {

    }

    private TemplateDocument(
        string name,
        string extension,
        User owner,
        Guid ownerId,
        DocumentState state,
        TemplateType type,
        int version) : base(name, extension, owner, ownerId)
    {
        State = state;
        Type = type;
        Version = version;
    }


    public static Result<TemplateDocument> Create(
        string name,
        string extension,
        User owner,
        Guid ownerId,
        DocumentState state,
        TemplateType type,
        int version
    )
    {
        //TODO: Add validation logic here


        return Result<TemplateDocument>.Success(new TemplateDocument(name, extension, owner, ownerId, state, type, version));

    }


}

public enum TemplateType
{
    //TODO : Add more types as the need arises
    Word,
    Excel,
    Powerpoint,
    PDF
}


public enum DocumentState
{
    Draft,
    Published,
    Archived
}