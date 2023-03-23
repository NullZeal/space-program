using Microsoft.EntityFrameworkCore;
using SpaceProgramApi.Models;

namespace SpaceProgramApi.Data
{
    public class SpaceProgramApiContext : DbContext
    {
        public SpaceProgramApiContext (DbContextOptions<SpaceProgramApiContext> options)
            : base(options)
        {
        }

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

        public DbSet<SpaceProgramApi.Models.Officer> Officer { get; set; } = default!;
        public DbSet<SpaceProgramApi.Models.SpaceStation> SpaceStation { get; set; } = default!;
        public DbSet<SpaceProgramApi.Models.User> User { get; set; } = default!;
    }
}
