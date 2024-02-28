using AudiT.Domain.Entities;
using AudIT.Domain.Misc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Action = AudiT.Domain.Entities.Action;

namespace AudIT.Infrastructure;

public class AudITContext : IdentityDbContext<User>
{
    public DbSet<Department> Departments { get; set; }

    public DbSet<Institution> Institutions { get; set; }

    public DbSet<StandaloneDocument> StandaloneDocuments { get; set; }

    public DbSet<TemplateDocument> TemplateDocuments { get; set; }

    public DbSet<AuditMissionDocument> AuditMissionDocument { get; set; }
    public DbSet<AuditMission> AuditMissions { get; set; }

    public DbSet<Action> Activities { get; set; }

    public DbSet<AuditMissionObjectives> AuditMissionObjectives { get; set; }

    public DbSet<Objective> Objective { get; set; }


    public AudITContext()
    {
    }

    public AudITContext(DbContextOptions<AudITContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(
            $"Data Source={"D:\\Projects\\AudIT\\AudIT\\AudIT\\AudIT.Infrastructure\\database.db"}");
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<AuditMission>()
    //         .HasOne(a => a.User)
    //         .WithMany(u => u.AuditMissions)
    //         .HasForeignKey(a => a.UserId)
    //         .OnDelete(DeleteBehavior.Cascade);
    //
    //     modelBuilder.Entity<Action>()
    //         .HasOne(a => a.User)
    //         .WithMany(u => u.Actions)
    //         .HasForeignKey(a => a.UserId)
    //         .OnDelete(DeleteBehavior.Cascade);
    //
    //     modelBuilder.Entity<BaseDocument>()
    //         .HasOne(b => b.User)
    //         .WithMany(u => u.BaseDocuments)
    //         .HasForeignKey(b => b.UserId)
    //         .OnDelete(DeleteBehavior.Cascade);
    //
    //     base.OnModelCreating(modelBuilder);
    // }
}