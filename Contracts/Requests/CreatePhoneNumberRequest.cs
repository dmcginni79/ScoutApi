
namespace ScoutApi.Contracts.Requests;

public class CreatePhoneNumberRequest
{
    public Guid Id { get; set; }
    public Guid GuardianId { get; set; }
    public string Number { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
}