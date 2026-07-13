namespace RxPad.Domain.Entities;

public class PrescriptionMedicine
{
    public Guid Id { get; private set; }
    public Guid PrescriptionId { get; private set; }
    public Guid MedicineId { get; private set; }

    public string Dosage { get; private set; } = string.Empty;       // e.g. "1+0+1"
    public string Duration { get; private set; } = string.Empty;     // e.g. "7 days"
    public string? Instruction { get; private set; }                  // e.g. "after meal"
    public int SortOrder { get; private set; }                        // Display order on prescription

    // Navigation properties
    public Prescription? Prescription { get; private set; }
    public Medicine? Medicine { get; private set; }

    private PrescriptionMedicine() { }

    public static PrescriptionMedicine Create(
        Guid prescriptionId,
        Guid medicineId,
        string dosage,
        string duration,
        string? instruction,
        int sortOrder)
    {
        return new PrescriptionMedicine
        {
            Id = Guid.NewGuid(),
            PrescriptionId = prescriptionId,
            MedicineId = medicineId,
            Dosage = dosage,
            Duration = duration,
            Instruction = instruction,
            SortOrder = sortOrder
        };
    }
}