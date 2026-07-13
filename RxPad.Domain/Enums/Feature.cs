namespace RxPad.Domain.Enums;

// Each value represents a feature name stored in PlanFeature table
// Use Feature.PatientHistory.ToString() to match DB value
public enum Feature
{
    CreatePrescription,
    GeneratePdf,
    QrCode,
    PatientHistory,
    FavouriteMedicines,
    CustomLetterhead,
    PrescriptionTemplates,
    Analytics,
    MedicineInteractionWarning
}