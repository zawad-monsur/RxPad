using RxPad.Domain.Enums;

namespace RxPad.Domain.Entities;

public class Subscription
{
    public Guid Id { get; private set; }
    public Guid DoctorId { get; private set; }
    public SubscriptionPlan Plan { get; private set; }
    public SubscriptionStatus Status { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }

    // Tracks who changed the subscription — "Manual" now, "SSLCommerz" later
    public string UpdatedBy { get; private set; } = string.Empty;
    public DateTime UpdatedAt { get; private set; }

    // Navigation property
    public Doctor? Doctor { get; private set; }

    private Subscription() { }

    public static Subscription CreateTrial(Guid doctorId)
    {
        return new Subscription
        {
            Id = Guid.NewGuid(),
            DoctorId = doctorId,
            Plan = SubscriptionPlan.Free,
            Status = SubscriptionStatus.Active,
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddDays(30), // 30 day free trial
            UpdatedBy = "System",
            UpdatedAt = DateTime.UtcNow
        };
    }

    public void ChangePlan(SubscriptionPlan newPlan, int durationDays, string updatedBy)
    {
        Plan = newPlan;
        Status = SubscriptionStatus.Active;
        StartDate = DateTime.UtcNow;
        EndDate = DateTime.UtcNow.AddDays(durationDays);
        UpdatedBy = updatedBy; // "Manual" or "SSLCommerz"
        UpdatedAt = DateTime.UtcNow;
    }

    public void Expire()
    {
        Status = SubscriptionStatus.Expired;
        UpdatedBy = "System"; // background job does this
        UpdatedAt = DateTime.UtcNow;
    }

    public bool IsActive() => Status == SubscriptionStatus.Active && EndDate > DateTime.UtcNow;
}