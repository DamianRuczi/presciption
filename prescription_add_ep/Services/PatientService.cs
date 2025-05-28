using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prescription_add_ep.Data;
using prescription_add_ep.DTO;
using prescription_add_ep.Models;

namespace prescription_add_ep.Services;

public interface IPatientService
{
    Task<Patient> GeneratePatient(PatientRequestDto request);
    Task<IActionResult> GetPatientDetailsAsync(int patientId);
}

public class PatientService(MyDbContext context) : IPatientService
{
    private readonly MyDbContext _context = context;

    public async Task<Patient> GeneratePatient(PatientRequestDto request)
    {
        var patient = new Patient
        {
            FirstName = string.IsNullOrWhiteSpace(request.FirstName) ? null : request.FirstName,
            LastName = string.IsNullOrWhiteSpace(request.LastName) ? null : request.LastName
        };

        _context.Patients.Add(patient);

        return patient;
    }
    
    public async Task<IActionResult> GetPatientDetailsAsync(int patientId)
    {
        var patient = await _context.Patients
            .Include(p => p.Prescriptions)
            .ThenInclude(p => p.Doctor)
            .Include(p => p.Prescriptions)
            .ThenInclude(p => p.PrescriptionMedicaments)
            .ThenInclude(pm => pm.Medicament)
            .FirstOrDefaultAsync(p => p.PatientId == patientId);

        if (patient == null)
        {
            return new NotFoundObjectResult($"Patient with ID {patientId} not found");
        }

        var patientDetails = new PatientDetailsDto
        {
            PatientId = patient.PatientId,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            Prescriptions = patient.Prescriptions
                .OrderBy(p => p.DueDate)
                .Select(p => new PrescriptionDetailsDto
                {
                    PrescriptionId = p.Id,
                    Date = p.Date,
                    DueDate = p.DueDate,
                    Doctor = new DoctorDetailsDto
                    {
                        DoctorId = p.Doctor.DoctorId,
                        FirstName = p.Doctor.FirstName,
                        LastName = p.Doctor.LastName,
                        Email = p.Doctor.Email
                    },
                    Medicaments = p.PrescriptionMedicaments
                        .Select(pm => new MedicamentDetailsDto
                        {
                            MedicamentId = pm.Medicament.MedicamentId,
                            Name = pm.Medicament.Name,
                            Description = pm.Medicament.Description,
                            Type = pm.Medicament.Type,
                            Dose = pm.Dose,
                            Details = pm.Details
                        }).ToList()
                }).ToList()
        };

        return new OkObjectResult(patientDetails);
    }
}