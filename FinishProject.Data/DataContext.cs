using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinishProject;
using FinishProject.Core.Models;
using Microsoft.Extensions.Configuration;

namespace FinishProject.Data
{
 

    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
            .HasKey(u => u.Id); // הגדרת מפתח ראשי עבור Employee

            modelBuilder.Entity<TimeLog>()
                .HasKey(p => p.Id);
               // הגדרת מפתח ראשי עבור TimeLog

            modelBuilder.Entity<TimeLog>()
               .HasOne(t=>t.Employee) // קשר ל-Employee
                .WithMany(u => u.TimeLogs) // קשר לקולקציה ב-Employee
                .HasForeignKey(p => p.EmployeeId) // הגדרת EmployeeId כמפתח זר
                .OnDelete(DeleteBehavior.Cascade); // התנהגות מחיקה

            modelBuilder.Entity<TimeLog>()
                .Property(e => e.Date)
                .HasConversion(
                    v => v.ToDateTime(TimeOnly.MinValue), // המרה ל-DateTime
                    v => DateOnly.FromDateTime(v)); // המרה מ-DateTime

            modelBuilder.Entity<TimeLog>()
                .Property(e => e.StartTime)
                .HasConversion(
                    v => v.ToTimeSpan(), // המרה ל-TimeSpan
                    v => TimeOnly.FromTimeSpan(v)); // המרה מ-TimeSpan

            modelBuilder.Entity<TimeLog>()
               .Property(e => e.EndTime)
               .HasConversion(
                   v => v.ToTimeSpan(), // המרה ל-TimeSpan
                   v => TimeOnly.FromTimeSpan(v)); // המרה מ-TimeSpan

            modelBuilder.Entity<Request>()
        .HasKey(a => a.Id); // הגדרת המפתח הראשי

            modelBuilder.Entity<Request>()
                .Property(a => a.Reason)
                .IsRequired();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["DbConnectionString"]);
        }
       

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<TimeLog> TimeLogs { get; set; }
    }

}