namespace RxPad.Domain.Entities;

public class Doctor
{
    public Guid Id { get; private set; }
    public string FullName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public string Phone { get; private set; } = string.Empty;

    // Letterhead info for prescription
    public string BmdcNumber { get; private set; } = string.Empty;
    public string Degrees { get; private set; } = string.Empty;
    public string ChamberName { get; private set; } = string.Empty;
    public string ChamberAddress { get; private set; } = string.Empty;
    public string ChamberTiming { get; private set; } = string.Empty;

    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }

    // Navigation property — EF Core relationship
    public Subscription? Subscription { get; private set; }

    private Doctor() { } 

    public static Doctor Create(
        string fullName,
        string email,
        string passwordHash,
        string phone,
        string bmdcNumber,
        string degrees)
    {
        return new Doctor
        {
            Id = Guid.NewGuid(),
            FullName = fullName,
            Email = email,
            PasswordHash = passwordHash,
            Phone = phone,
            BmdcNumber = bmdcNumber,
            Degrees = degrees,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };
    }

   
    public void UpdateChamberInfo(string chamberName, string address, string timing)
    {
        ChamberName = chamberName;
        ChamberAddress = address;
        ChamberTiming = timing;
    }

    public void UpdatePassword(string newPasswordHash)
    {
        PasswordHash = newPasswordHash;
    }
}