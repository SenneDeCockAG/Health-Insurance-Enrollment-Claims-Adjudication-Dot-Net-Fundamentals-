using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
namespace Console.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Member> Members => Set<Member>();
        public DbSet<Plan> Plans => Set<Plan>();
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();
        public DbSet<MedicalClaim> MedicalClaims => Set<MedicalClaim>();
        public DbSet<ClaimLine> ClaimLines => Set<ClaimLine>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={Path.Combine("..", "..", "..", "insurance.sqlite")}")
                          .LogTo((m) => Debug.WriteLine(m))
                          .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().ToTable("Members");
            modelBuilder.Entity<Plan>().ToTable("Plans");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollments");
            modelBuilder.Entity<MedicalClaim>().ToTable("MedicalClaims");
            modelBuilder.Entity<ClaimLine>().ToTable("ClaimLines");
        }

        public void Seed()
        {
            Database.EnsureDeleted(); 
            Database.EnsureCreated();
            var members = Models.Seed.Create();
            Members.AddRange(members);
            SaveChanges();
        }
    }
}
