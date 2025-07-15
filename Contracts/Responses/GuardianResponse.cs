using ScoutApi.PhoneNumbers;

namespace ScoutApi.Contracts.Responses;

public class GuardianResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public ICollection<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();
    public bool IsPrimaryGuardian { get; set; }
}