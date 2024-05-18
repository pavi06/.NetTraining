using EmployeeRequestTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EmployeeRequestTrackerAPI.Contexts
{
    public class RequestTrackerContext : DbContext
    {
        public RequestTrackerContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Request>()
               .HasOne(r => r.RaisedByEmployee)
               .WithMany(e => e.RequestsRaised)
               .HasForeignKey(r => r.RequestRaisedBy)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();

            modelBuilder.Entity<Request>()
               .HasOne(r => r.RequestClosedByEmployee)
               .WithMany(e => e.RequestsClosed)
               .HasForeignKey(r => r.RequestClosedBy)
               .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
