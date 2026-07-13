using RxPad.Domain.Entities;

namespace RxPad.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Doctor> Doctors { get; }
    IRepository<Patient> Patients { get; }
    IRepository<Prescription> Prescriptions { get; }
    IRepository<PrescriptionMedicine> PrescriptionMedicines { get; }
    IRepository<Medicine> Medicines { get; }
    IRepository<Subscription> Subscriptions { get; }
    IRepository<PlanFeature> PlanFeatures { get; }

    Task<int> SaveChangesAsync();
}