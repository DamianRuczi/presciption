using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prescription_add_ep.Data;
using prescription_add_ep.DTO;
using prescription_add_ep.Models;

namespace prescription_add_ep.Services;

public interface IPrescriptionService
{
    Task<IActionResult> AddPrescriptionAsync(PrescriptionRequestDto request);
}

public class PrescriptionService : IPrescriptionService
{
    private readonly MyDbContext _context;
    private readonly IPatientService _patientService;

    public PrescriptionService(MyDbContext context, IPatientService patientService)
    {
        _context = context;
        _patientService = patientService;
    }

    public async Task<IActionResult> AddPrescriptionAsync(PrescriptionRequestDto request)
    {
        if (request.DueDate < request.Date)
        {
            return new BadRequestObjectResult("DueDate must be greater than or equal to Date");
        }


        if (request.Medicaments.Count > 10)
        {
            return new BadRequestObjectResult("Prescription cannot contain more than 10 medicament's");
        }


        var doctor = await _context.Doctors.FindAsync(request.DoctorId);
        if (doctor == null)
        {
            return new NotFoundObjectResult($"Doctor with ID {request.DoctorId} not found");
        }


        foreach (var med in request.Medicaments)
        {
            if (!await _context.Medicaments.AnyAsync(m => m.MedicamentId == med.MedicamentId))
            {
                return new BadRequestObjectResult($"Medicament with ID {med.MedicamentId} not found");
            }
        }

        var patient = await _context.Patients.FindAsync(request.PatientId) ?? await _patientService.GeneratePatient(
            new PatientRequestDto() { FirstName = request.PatientFirstName, LastName = request.PatientLastName });

        var prescription = new Prescription
        {
            Date = request.Date,
            DueDate = request.DueDate,
            Patient = patient,
            DoctorId = request.DoctorId,
            PrescriptionMedicaments = request.Medicaments.Select(m => new PrescriptionMedicament
            {
                MedicamentId = m.MedicamentId,
                Dose = m.Dose,
                Details = m.Details
            }).ToList()
        };

        try
        {
            prescription.ValidateMedicaments();
        }
        catch (ValidationException ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }

        _context.Prescriptions.Add(prescription);
        await _context.SaveChangesAsync();

        return new OkObjectResult(new
        {
            PrescriptionId = prescription.Id,
            Message = "Prescription created successfully"
        });
    }
}