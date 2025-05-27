using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace prescription_add_ep.Models;

[Table("Prescription")]

public class Prescription
{
    [Key] public int Id { get; set; }


    public DateTime Date { get; set; }

    public DateTime DueDate { get; set; }

    [Column("PatientId")] public int PatientId { get; set; }

    [ForeignKey(nameof(PatientId))] public virtual Patient Patient { get; set; } = null!;
    
    [Column("DoctorId")] public int DoctorId { get; set; }

    [ForeignKey(nameof(DoctorId))] public virtual Doctor Doctor { get; set; } = null!;
    
    public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; } = null!;

    public void ValidateMedicaments()
    {
        if (PrescriptionMedicaments.Count > 10)
            throw new ValidationException("Recepta nie może mieć więcej niż 10 leków.");
    }
}