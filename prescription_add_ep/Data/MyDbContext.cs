using Microsoft.EntityFrameworkCore;
using prescription_add_ep.Models;

namespace prescription_add_ep.Data;

public class MyDbContext : DbContext
{
    
    public DbSet<Doctor> Doctors { get; set; } = null!;
    public DbSet<Patient> Patients { get; set; } = null!;
    public DbSet<Medicament> Medicaments { get; set; } = null!;
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; } = null!;
    public DbSet<Prescription> Prescriptions { get; set; } = null!;
    
    public MyDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var patients = new List<Patient>()
        {
            new ()
            {
                PatientId = 1,
                FirstName = "Alice",
                LastName = "Smith",
                DateOfBirth = new DateTime(1990, 1, 1)
            },
            new ()
            {
                PatientId = 2,
                FirstName = "Bob",
                LastName = "Johnson",
                DateOfBirth = new DateTime(1985, 5, 15)
            }
        };

        var doctors = new List<Doctor>
        {
            new()
            {
                DoctorId = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "email@emial.com"
            },
            new()
            {
                DoctorId = 2,
                FirstName = "Jane",
                LastName = "Doe",
                Email = "email@emial.com"
            }
        };


        var medicaments = new List<Medicament>
        {
            new()
            {
                MedicamentId = 1,
                Name = "Aspirin",
                Description = "Pain reliever",
                Type = "Tablet"
            },
            new()
            {
                MedicamentId = 2,
                Name = "Ibuprofen",
                Description = "Anti-inflammatory",
                Type = "Tablet"
            }
        };
       
        
        modelBuilder.Entity<Doctor>().HasData(doctors);
        modelBuilder.Entity<Medicament>().HasData(medicaments);
        modelBuilder.Entity<Patient>().HasData(patients);

    }
}