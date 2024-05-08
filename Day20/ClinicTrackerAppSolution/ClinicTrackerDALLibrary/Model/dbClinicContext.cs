using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClinicTrackerDALLibrary.Model
{
    public partial class dbClinicContext : DbContext
    {
        public dbClinicContext()
        {
        }

        public dbClinicContext(DbContextOptions<dbClinicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source='853CBX3\\SQLEXPRESS';Integrated Security=true;Initial Catalog=dbClinic");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AppointmentDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("appointmentDateTime");

                entity.Property(e => e.AppointmentDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("appointmentDescription");

                entity.Property(e => e.AppointmentStatus)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("appointmentStatus");

                entity.Property(e => e.DoctorId).HasColumnName("doctorId");

                entity.Property(e => e.PatientId).HasColumnName("patientId");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("fk_doctorId");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("fk_patientId");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("Doctor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.DocName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("docName");

                entity.Property(e => e.Experience).HasColumnName("experience");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.Qualification)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("qualification");

                entity.Property(e => e.Specialization)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("specialization");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.BloodGroup)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("bloodGroup");

                entity.Property(e => e.ContactAddress)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("contactAddress");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.PatientName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("patientName");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
