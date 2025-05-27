using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prescription_add_ep.Models;

[Table("Medicament")]
public class Medicament
{
    [Key]
    public int MedicamentId { get; set; }
    
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    
    [MaxLength(100)]
    public string Description { get; set; } = null!;
    
    [MaxLength(100)]
    public string Type { get; set; } = null!;
    
    public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; } = null!;
}