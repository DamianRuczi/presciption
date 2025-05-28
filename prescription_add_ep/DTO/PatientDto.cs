namespace prescription_add_ep.DTO;


public class PatientRequestDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
public class PatientDetailsDto
{
    public int PatientId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public List<PrescriptionDetailsDto> Prescriptions { get; set; } = new();
}
