using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace prescription_add_ep.Models;

[Table("PrescriptionMedicament")]

[PrimaryKey(nameof(PrescriptionId), nameof(MedicamentId))]
public class PrescriptionMedicament
{
    [Key, Column(Order = 0)] public int PrescriptionId { get; set; }
    [Key, Column(Order = 1)] public int MedicamentId { get; set; }
    
    [ForeignKey(nameof(PrescriptionId))] public virtual Prescription Prescription { get; set; } = null!;
    
    [ForeignKey(nameof(MedicamentId))] public virtual Medicament Medicament { get; set; } = null!;
    
    public int Dose { get; set; } = 0;
    
    [MaxLength(100)]
    public string Details { get; set; } = string.Empty;
}