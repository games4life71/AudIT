﻿using AudiT.Domain.Entities;
using AudIT.Domain.Misc;
using Microsoft.IdentityModel.Tokens;

namespace AudIT.Applicationa.Contracts.AbstractRepositories;

public interface IActivityRepository:IRepository<Activity>
{


    public Task<Result<Activity>>  AttachDocumentAsync (Guid activityId, BaseDocument document);


    public Task<Result<Activity>> FindByWithDocumentsAsync(Guid id);


    public Task<Result<Activity>> RemoveDocumentAsync(Guid activityId, Guid documentId);

}