namespace prescription_add_ep.DTO;

public class MedicamentDetailsDto
{
    public int MedicamentId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public int Dose { get; set; }
    public string Details { get; set; } = string.Empty;
}