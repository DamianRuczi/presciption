using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prescription_add_ep.Models;

[Table("Doctor")]
public class Doctor
{
    [Key] public int DoctorId { get; set; }

    [MaxLength(100)] public string FirstName { get; set; } = null!;

    [MaxLength(100)] public string LastName { get; set; } = null!;

    [MaxLength(100), EmailAddress] public string Email { get; set; } = null!;
    
    public virtual ICollection<Prescription> Prescriptions { get; set; } = null!;
}