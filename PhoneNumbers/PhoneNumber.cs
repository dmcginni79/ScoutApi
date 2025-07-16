using ScoutApi.Guardians;

namespace ScoutApi.PhoneNumbers;

public class PhoneNumber
{
    public Guid Id { get; set; }
    public Guid GuardianId { get; set; }
    public Guardian Guardian { get; set; } = null!;
    public string Number { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // e.g., "Mobile", "Home"
}