namespace ScoutApi.PhoneNumbers;

public class PhoneNumber
{
    public string Number { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // e.g., "Mobile", "Home"
}