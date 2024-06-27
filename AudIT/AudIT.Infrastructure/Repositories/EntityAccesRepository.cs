﻿using AudIT.Applicationa.Contracts.AbstractRepositories;
using AudiT.Domain.Entities;
using AudIT.Domain.Misc;
using Microsoft.EntityFrameworkCore;

namespace AudIT.Infrastructure.Repositories;

public class EntityAccesRepository : BaseRepository<EntityAcces>, IEntityAccesRepository
{
    private readonly AudITContext _context;

    public EntityAccesRepository(AudITContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Result<EntityAcces>> FindByEntityIdAsync(Guid entityId, EntityType entityType, string userId)
    {
        var entityAcces =
            await _context.EntityAcces
                .FirstOrDefaultAsync(x => x.EntityId == entityId && x.Type == entityType && x.UserId == userId.ToString());

        if (entityAcces == null)
        {
            return Result<EntityAcces>.Failure("Entity acces not found");
        }

        return Result<EntityAcces>.Success(entityAcces);
    }

    public async Task<Result<List<EntityAcces>>> GetAllByUserId(Guid requestUserId)
    {
        var entityAcces = await _context.EntityAcces
            .Where(x => x.UserId == requestUserId.ToString())
            .ToListAsync();


        if (!entityAcces.Any())
        {
            return Result<List<EntityAcces>>.Failure("Entity acces not found");
        }

        return Result<List<EntityAcces>>.Success(entityAcces);
    }

    public async Task<Result<List<EntityAcces>>> GetAllGrantedAccesByUserId(Guid requestUserId)
    {
        var entityAcces = await _context.EntityAcces
            .Where(x => x.GrantedByUserId == requestUserId.ToString())
            .Include(x=>x.GrantedByUser)
            .ToListAsync();



        if (entityAcces.Any())
        {
            foreach (var entity in entityAcces)
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == entity.UserId);

                if (user != null)
                {
                    entity.User = user;
                }

            }
            return Result<List<EntityAcces>>.Success(entityAcces);
        }
            return Result<List<EntityAcces>>.Failure("Entity acces not found");


    }
}