namespace SeedApp.Models
{
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options) { }


        public DbSet<Member> Members { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationCheckin> LocationCheckins { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
              .ToTable("Member", "dbo")
              .HasKey(t => t.MemberId);


            modelBuilder.Entity<Location>()
                .ToTable("Location", "dbo")
                .HasKey(t => t.LocationId);


            modelBuilder.Entity<LocationCheckin>()
                .ToTable("LocationCheckin", "dbo")
                .HasKey(t => t.LocationCheckinId);

            modelBuilder.Entity<LocationCheckin>()
                .HasOne(t => t.Member).WithMany().HasForeignKey(t => t.MemberId);

            modelBuilder.Entity<LocationCheckin>()
                .HasOne(t => t.Location).WithMany().HasForeignKey(t => t.LocationId);
        }
    }
}