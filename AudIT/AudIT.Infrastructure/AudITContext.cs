using AudiT.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AudIT.Infrastructure;

public class AudITContext:DbContext
{
    // private DbSet<Department> Departments { get; set; }
    // private DbSet<Institution> Institutions { get; set; }
    private DbSet<User> Users { get; set; }

    public AudITContext()
    {

    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={"D:\\Projects\\AudIT\\AudIT\\AudIT\\AudIT.Infrastructure\\database.db"}");

    }
}