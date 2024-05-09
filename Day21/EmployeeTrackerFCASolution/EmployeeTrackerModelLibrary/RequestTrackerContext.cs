using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackerModelLibrary
{
    public class RequestTrackerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=853CBX3\SQLEXPRESS;Integrated Security=true;Initial Catalog=dbEmployeeTrackerCF;");
        }

        //entity for which table has to be created , must be specified with DbSet
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //to populate data to the db
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 101, Name = "Ramu", Password = "ramu123", Role = "Admin" },
                new Employee { Id = 102, Name = "Somu", Password = "somu123", Role = "Admin" },
                new Employee { Id = 103, Name = "Bimu", Password = "bimu123", Role = "User" }
                );

            //assigning primary key to the entity Request
            modelBuilder.Entity<Request>().HasKey(r => r.RequestNumber);

            //Entity mapping
            modelBuilder.Entity<Request>()
               .HasOne(r => r.RaisedByEmployee) //navigation property in request (Employee obj)
               .WithMany(e => e.RequestsRaised) //list of requests of an employee
               .HasForeignKey(r => r.RequestRaisedBy)  //foreign key
               .OnDelete(DeleteBehavior.Restrict) //restricting the cascading
               .IsRequired();  //assigning the not null constraint

            modelBuilder.Entity<Request>()
               .HasOne(r => r.RequestClosedByEmployee)
               .WithMany(e => e.RequestsClosed)
               .HasForeignKey(r => r.RequestClosedBy)
               .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
