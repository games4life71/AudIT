using AudiT.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AudIT.Infrastructure;

public class AudITContext : DbContext
{
    public  DbSet<Department> Departments { get; set; }

    public DbSet<Institution> Institutions { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<StandaloneDocument> StandaloneDocuments { get; set; }

    public DbSet<TemplateDocument> TemplateDocuments { get; set; }

    public DbSet<AuditMission> AuditMissions { get; set; }

    public DbSet<Activity> Activities { get; set; }

    public AudITContext()
    {
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(
            $"Data Source={"D:\\Projects\\AudIT\\AudIT\\AudIT\\AudIT.Infrastructure\\database.db"}");
    }
}