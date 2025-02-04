﻿using System.Diagnostics;
using System.Security.Authentication;
using System.Security.Claims;
using AudiT.Domain.Entities;
using AudIT.Domain.Misc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Activity = AudiT.Domain.Entities.Activity;

namespace AudIT.Infrastructure;

public class AudITContext : IdentityDbContext<User>
{
    public DbSet<Department> Departments { get; set; }

    public DbSet<Institution> Institutions { get; set; }

    public DbSet<StandaloneDocument> StandaloneDocuments { get; set; }

    public DbSet<TemplateDocument> TemplateDocuments { get; set; }

    public DbSet<AuditMissionDocument> AuditMissionDocument { get; set; }
    public DbSet<AuditMission> AuditMissions { get; set; }

    public DbSet<Recommendation> Recommendations { get; set; }

    public DbSet<AuditMissionRecommendations> AuditMissionRecommendations { get; set; }

    public DbSet<BaseDocument> BaseDocuments { get; set; }

    public DbSet<Activity> Activities { get; set; }

    public DbSet<AuditMissionObjectives> AuditMissionObjectives { get; set; }

    public DbSet<Objective> Objective { get; set; }
    public DbSet<ObjectiveAction> ObjectiveAction { get; set; }

    public DbSet<ActionRisk> ActionRisk { get; set; }

    public DbSet<UserInstitution> UserInstitution { get; set; }
    public DbSet<ObjectiveActionFiap> ObjectiveActionFiap { get; set; }

    //Services
    private readonly IHttpContextAccessor _httpContextAccessor;


    public AudITContext()
    {
    }

    public AudITContext(DbContextOptions<AudITContext> options, IHttpContextAccessor httpContextAccessor) :
        base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(
            $"Data Source={"D:\\Projects\\AudIT\\AudIT\\AudIT\\AudIT.Infrastructure\\database.db"}");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //
        // modelBuilder.Entity<User>()
        //     .HasIndex(u => u.InstitutionId)
        //     .IsUnique(false); // This ensures that InstitutionId is not a unique key

        // modelBuilder.Entity<User>()
        //     .HasOne(u => u.Institution);
    }

    public override int SaveChanges()
    {
         UpdateAuditableEntities();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = new CancellationToken())
    {
         UpdateAuditableEntities();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }


    /// <summary>
    /// This method is used to update the AuditableEntity properties before saving the changes
    /// </summary>
    private void UpdateAuditableEntities()
    {
        var now = DateTime.Now;
        var user = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (user == null)
            user =Guid.Empty.ToString();

        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = user;
                    entry.Entity.LastModifiedDate = now;
                    entry.Entity.CreatedDate = now;
                    entry.Entity.LastModifiedBy = user;
                    entry.Entity.WriteAccesUserId.Add(Guid.Parse(user));
                    entry.Entity.ReadAccesUserId.Add(Guid.Parse(user));
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedBy = user;
                    entry.Entity.LastModifiedDate = now;
                    break;
                case EntityState.Detached:
                    break;
                case EntityState.Unchanged:
                    break;
                case EntityState.Deleted:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}