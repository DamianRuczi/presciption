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
}