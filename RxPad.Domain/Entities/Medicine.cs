namespace RxPad.Domain.Entities;

public class Medicine
{
    public Guid Id { get; private set; }
    public string BrandName { get; private set; } = string.Empty;
    public string GenericName { get; private set; } = string.Empty;
    public string Strength { get; private set; } = string.Empty; // e.g. "500mg", "10mg"
    public string DosageForm { get; private set; } = string.Empty; // e.g. "Tablet", "Syrup"
    public string Manufacturer { get; private set; } = string.Empty;
    public bool IsActive { get; private set; }

    private Medicine() { }

    public static Medicine Create(string brandName, string genericName, string strength, string dosageForm, string manufacturer)
    {
        return new Medicine
        {
            Id = Guid.NewGuid(),
            BrandName = brandName,
            GenericName = genericName,
            Strength = strength,
            DosageForm = dosageForm,
            Manufacturer = manufacturer,
            IsActive = true
        };
    }
}