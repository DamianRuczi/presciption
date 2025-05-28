using Microsoft.AspNetCore.Mvc;
using prescription_add_ep.DTO;
using prescription_add_ep.Services;

namespace prescription_add_ep.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionController : ControllerBase
{
    private readonly IPrescriptionService _prescriptionService;

    public PrescriptionController(IPrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }

    [HttpPost]
    public async Task<IActionResult> AddPrescription([FromBody] PrescriptionRequestDto request)
    {
        return await _prescriptionService.AddPrescriptionAsync(request);
    }
}