// File: Contracts/Requests/CreateGuardianRequest.cs
using ScoutApi.Scouts;

namespace ScoutApi.Contracts.Requests;

public class CreateGuardianRequest
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public ICollection<Scout> Scouts { get; set; }
}