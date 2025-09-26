using eHealthApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace eHealthApp.Services
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Member> Members => Set<Member>();
        public DbSet<Plan> Plans => Set<Plan>();
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
            var dbPath = Path.Combine(projectRoot, "eHealthApp.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}").LogTo(Console.WriteLine).EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().ToTable("Members");
            modelBuilder.Entity<Plan>().ToTable("Plans");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollments");
        }
    }
}
