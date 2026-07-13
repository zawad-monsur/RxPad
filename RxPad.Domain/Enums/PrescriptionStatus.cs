namespace RxPad.Domain.Enums;

public enum PrescriptionStatus
{
    Draft = 1,      // Doctor still editing
    Finalized = 2,  // Ready to print
    Cancelled = 3
}