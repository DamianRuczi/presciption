using Microsoft.AspNetCore.Mvc;
using prescription_add_ep.Services;

namespace prescription_add_ep.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController(IPatientService patientService) : ControllerBase
{
    [HttpGet("{patientId}")]
    public async Task<IActionResult> GetPatientDetails(int patientId)
    {
        return await patientService.GetPatientDetailsAsync(patientId);
    }
}