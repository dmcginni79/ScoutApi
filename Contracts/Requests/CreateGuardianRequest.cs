// File: Contracts/Requests/CreateGuardianRequest.cs

using ScoutApi.PhoneNumbers;
using ScoutApi.Scouts;

namespace ScoutApi.Contracts.Requests;

public class CreateGuardianRequest
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public ICollection<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();
    public ICollection<Scout> Scouts { get; set; } = new List<Scout>();
    public bool IsPrimaryGuardian { get; set; } = false;
    public Guid ScoutId { get; set; } 
}