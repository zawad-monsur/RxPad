using RxPad.Domain.Enums;

namespace RxPad.Domain.Entities;

public class PlanFeature
{
    public Guid Id { get; private set; }
    public SubscriptionPlan Plan { get; private set; }

    // Feature name as constant string — e.g. "PatientHistory", "Templates"
    public string FeatureName { get; private set; } = string.Empty;
    public bool IsEnabled { get; private set; }

    private PlanFeature() { }

    public static PlanFeature Create(SubscriptionPlan plan, string featureName, bool isEnabled)
    {
        return new PlanFeature
        {
            Id = Guid.NewGuid(),
            Plan = plan,
            FeatureName = featureName,
            IsEnabled = isEnabled
        };
    }

    public void Toggle(bool isEnabled)
    {
        IsEnabled = isEnabled;
    }
}