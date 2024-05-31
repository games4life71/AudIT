using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudiT.Domain.Entities;
using AudIT.Domain.Misc;
using Microsoft.EntityFrameworkCore;

namespace AudIT.Infrastructure.Repositories;

public class BaseDocumentRepository : BaseRepository<BaseDocument>, IBaseDocumentRepository
{
    public BaseDocumentRepository(AudITContext context) : base(context)
    {
    }

    public async Task<Result<List<StandaloneDocument>>> GetDocumentsByDepartmentId(Guid requestDepartmentId)
    {
        var result = await _dbcContext.StandaloneDocuments
            .Where(x => x.DepartmentId == requestDepartmentId).ToListAsync();


        if (result.Count == 0)
            return Result<List<StandaloneDocument>>.Failure("No documents found for the given department id");


        return Result<List<StandaloneDocument>>.Success(result);
    }

    public async Task<Result<List<BaseDocument>>> GetDocumentsByUserId(Guid requestUserId)
    {
        try
        {
            var result = await _dbcContext.BaseDocuments
                .Where(x => x.OwnerId == requestUserId.ToString()).ToListAsync();

            return Result<List<BaseDocument>>.Success(result);
        }
        catch (Exception e)
        {
            return Result<List<BaseDocument>>.Failure(e.Message);
        }
    }

    public async Task<Result<List<BaseDocument>>> GetRecentDocumentsByUserIdAsync(Guid userId)
    {
        var result = await _dbcContext.BaseDocuments
            .Where(x => x.OwnerId == userId.ToString())
            .OrderByDescending(x => x.LastModifiedDate)
            .Take(3)
            .ToListAsync();

        if (result.Count == 0)
            return Result<List<BaseDocument>>.Failure("No documents found for the given user id");

        return Result<List<BaseDocument>>.Success(result);
    }
}