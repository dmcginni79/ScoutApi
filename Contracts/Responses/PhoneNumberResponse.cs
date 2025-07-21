using ScoutApi.PhoneNumbers;

namespace ScoutApi.Contracts.Responses;

public class PhoneNumberResponse
{
    public Guid Id { get; set; }
    public Guid GuardianId { get; set; }
    public GuardianResponse Guardian { get; set; } = null!; 
    public string Number { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
}