using AudiT.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Action = AudiT.Domain.Entities.Action;

namespace AudIT.Infrastructure;

public class AudITContext : DbContext
{
    public DbSet<Department> Departments { get; set; }

    public DbSet<Institution> Institutions { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<StandaloneDocument> StandaloneDocuments { get; set; }

    public DbSet<TemplateDocument> TemplateDocuments { get; set; }

    public DbSet<AuditMissionDocument> AuditMissionDocument{ get; set; }
    public DbSet<AuditMission> AuditMissions { get; set; }

    public DbSet<Action> Activities { get; set; }

    public DbSet<AuditMissionObjectives> AuditMissionObjectives { get; set; }

    public DbSet<Objective> Objective { get; set; }

    public AudITContext()
    {
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(
            $"Data Source={"D:\\Projects\\AudIT\\AudIT\\AudIT\\AudIT.Infrastructure\\database.db"}");
    }
}