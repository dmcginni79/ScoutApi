using ScoutApi.PhoneNumbers;
using ScoutApi.Scouts;

namespace ScoutApi.Guardians;

public class Guardian
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public List<PhoneNumber> PhoneNumbers { get; set; } = new();
    public List<Scout> Scouts { get; set; } = new ();
    public bool IsPrimaryGuardian { get; set; } = true;
}