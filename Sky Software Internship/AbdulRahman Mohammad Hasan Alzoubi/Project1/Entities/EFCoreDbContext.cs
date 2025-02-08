using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project1.Entities
{
    public class EFCoreDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<VacationType> VacationsTypes { get; set; }
        public DbSet<RequestState> RequestStates { get; set; }
        public DbSet<VacationRequest> VacationRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder.UseSqlServer("Server=LAPTOP-O13CF61E\\SQLEXPRESS;Database=EmployeeAffairs;TrustServerCertificate=True;Trusted_Connection=true;");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne<Department>(e => e.Department)
                .WithMany()
                .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<Employee>()
                .HasOne<Position>(e => e.Position)
                .WithMany()
                .HasForeignKey(e => e.PositionId);

            modelBuilder.Entity<Employee>()
                .HasOne<Employee>(e => e.ReportedToEmployee)
                .WithMany()
                .HasForeignKey(e => e.ReportedToEmpNum)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<VacationRequest>()
                .HasOne<Employee>(vr => vr.Employee)
                .WithMany()
                .HasForeignKey(vr => vr.EmployeeNumber);

            modelBuilder.Entity<VacationRequest>()
                .HasOne<VacationType>(vr => vr.VacationType)
                .WithMany()
                .HasForeignKey(vr => vr.VacationTypeCode);

            modelBuilder.Entity<VacationRequest>()
                .HasOne<RequestState>(vr => vr.RequestState)
                .WithMany()
                .HasForeignKey(vr => vr.StateId);
        }
    }
}
