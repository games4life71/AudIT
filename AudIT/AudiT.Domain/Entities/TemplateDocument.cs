﻿using AudIT.Domain.Misc;

namespace AudiT.Domain.Entities;

public class TemplateDocument:BaseDocument
{

    //the state of which the document is in : Draft, Published, Archived etc
    public DocumentState State { get; private set; }

    public TemplateTypeStage Type { get; private set; }

    public string Version { get; private set; }


    public TemplateDocument()
    {

    }

    private TemplateDocument(
        string name,
        string extension,
        User owner,
        Guid ownerId,
        DocumentState state,
        TemplateTypeStage type,
        string version) : base(name, extension, owner, ownerId)
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
        TemplateTypeStage type,
        string version
    )
    {
        //TODO: Add validation logic here


        return Result<TemplateDocument>.Success(new TemplateDocument(name, extension, owner, ownerId, state, type, version));

    }


}

public enum TemplateTypeStage
{
    //TODO : Add more types as the need arises
     PregatireaMisiunii,
     InterventieLaFataLocului,
     RaportareRezultate,
     UrmarireaRecomandari
}


public enum DocumentState
{
   Draft,
   Published,
   Archived
}