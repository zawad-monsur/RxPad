namespace RxPad.Domain.Entities;

public class Patient
{
    public Guid Id { get; private set; }
    public Guid DoctorId { get; private set; } // Each doctor has their own patient list
    public string FullName { get; private set; } = string.Empty;
    public string Phone { get; private set; } = string.Empty;
    public int Age { get; private set; }
    public string Sex { get; private set; } = string.Empty; // "Male", "Female", "Other"
    public DateTime? DateOfBirth { get; private set; }
    public DateTime CreatedAt { get; private set; }

    // Navigation properties
    public Doctor? Doctor { get; private set; }
    public ICollection<Prescription> Prescriptions { get; private set; } = new List<Prescription>();

    private Patient() { }

    public static Patient Create(Guid doctorId, string fullName, string phone, int age, string sex, DateTime? dateOfBirth = null)
    {
        return new Patient
        {
            Id = Guid.NewGuid(),
            DoctorId = doctorId,
            FullName = fullName,
            Phone = phone,
            Age = age,
            Sex = sex,
            DateOfBirth = dateOfBirth,
            CreatedAt = DateTime.UtcNow
        };
    }

    public void Update(string fullName, string phone, int age, string sex)
    {
        FullName = fullName;
        Phone = phone;
        Age = age;
        Sex = sex;
    }
}