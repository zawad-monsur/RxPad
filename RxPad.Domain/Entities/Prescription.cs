using RxPad.Domain.Enums;

namespace RxPad.Domain.Entities;

public class Prescription
{
    public Guid Id { get; private set; }
    public Guid DoctorId { get; private set; }
    public Guid PatientId { get; private set; }
    public DateTime VisitDate { get; private set; }
    public DateTime? FollowUpDate { get; private set; }

    // Left column — clinical findings
    public string? ChiefComplaints { get; private set; }
    public string? History { get; private set; }
    public string? Findings { get; private set; } // BP, weight, temp etc.
    public string? Diagnosis { get; private set; }
    public string? TestsAdvised { get; private set; }
    public string? Instructions { get; private set; }
    public string? HandwritingNote { get; private set; } // Free text space

    public PrescriptionStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }

    // Navigation properties
    public Doctor? Doctor { get; private set; }
    public Patient? Patient { get; private set; }
    public ICollection<PrescriptionMedicine> Medicines { get; private set; } = new List<PrescriptionMedicine>();

    private Prescription() { }

    public static Prescription Create(Guid doctorId, Guid patientId, DateTime? followUpDate = null)
    {
        return new Prescription
        {
            Id = Guid.NewGuid(),
            DoctorId = doctorId,
            PatientId = patientId,
            VisitDate = DateTime.UtcNow,
            FollowUpDate = followUpDate,
            Status = PrescriptionStatus.Draft,
            CreatedAt = DateTime.UtcNow
        };
    }

    public void UpdateClinicalNotes(
        string? complaints,
        string? history,
        string? findings,
        string? diagnosis,
        string? testsAdvised,
        string? instructions,
        string? handwritingNote)
    {
        ChiefComplaints = complaints;
        History = history;
        Findings = findings;
        Diagnosis = diagnosis;
        TestsAdvised = testsAdvised;
        Instructions = instructions;
        HandwritingNote = handwritingNote;
    }

    public void Finalize() => Status = PrescriptionStatus.Finalized;
    public void AddMedicine(PrescriptionMedicine medicine) => Medicines.Add(medicine);
}