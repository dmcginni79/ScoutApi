using ScoutApi.Guardians;

namespace ScoutApi.PhoneNumbers;

public class PhoneNumber
{
    // private readonly IGuardianService _guardianRepository;
    //
    // public PhoneNumber(IGuardianService guardianRepository)
    // {
    //     _guardianRepository = guardianRepository;
    // }
    
    public Guid Id { get; init; }
    public Guid GuardianId { get; init; }
    public Guardian? Guardian { get; init; } // Navigation property, can be null if not loaded
    public string Number { get; init; } = string.Empty;
    public string Type { get; init; } = string.Empty; // e.g., "Mobile", "Home"
    
    // public Task<Guardian?> GetGuardianAsync() // Guardian
    // {
    //     return _guardianRepository.GetByIdAsync(GuardianId);
    // }

}