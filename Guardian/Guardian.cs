using ScoutApi.Scouts;

namespace ScoutApi.Entities;

public class Guardian
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public List<Scout> Scouts { get; set; } = new List<Scout>();
    public bool IsPrimaryGuardian { get; set; } = true;
}