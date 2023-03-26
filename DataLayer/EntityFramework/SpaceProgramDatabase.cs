using Microsoft.EntityFrameworkCore;
using SpaceProgram.DataLayer.Models;

namespace SpaceProgram.DataLayer.EntityFramework;

public class SpaceProgramDatabase : DbContext
{
    public DbSet<Officer> Officer { get; set; }
    public DbSet<SpaceStation> SpaceStation { get; set; }
    public DbSet<User> User { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);
    }

    private static string ConnectionString => "Server=localhost;Database=SpaceProgram;Trusted_Connection=True;TrustServerCertificate=True";

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<SpaceStation>().HasIndex(s => s.Name).IsUnique();
        modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
        modelBuilder.Entity<Officer>().HasIndex(o => o.Name).IsUnique();

        modelBuilder.Entity<SpaceStation>().Property(x => x.SpaceStationId).HasDefaultValueSql("NEWID()");
        modelBuilder.Entity<User>().Property(x => x.UserId).HasDefaultValueSql("NEWID()");
        modelBuilder.Entity<Officer>().Property(x => x.OfficerId).HasDefaultValueSql("NEWID()");
    }
}
