namespace prescription_add_ep.DTO;
public class PrescriptionRequestDto
{
    public int PatientId { get; set; }
    public string? PatientFirstName { get; set; }
    public string? PatientLastName { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public int DoctorId { get; set; }
    public List<MedicamentRequestDto> Medicaments { get; set; } = new();
}


public class MedicamentRequestDto
{
    public int MedicamentId { get; set; }
    public int Dose { get; set; }
    public string Details { get; set; } = string.Empty;
}




public class PrescriptionDetailsDto
{
    public int PrescriptionId { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public DoctorDetailsDto Doctor { get; set; } = null!;
    public List<MedicamentDetailsDto> Medicaments { get; set; } = new();
}