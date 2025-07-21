using System.Collections.Generic;

namespace ScoutApi.Contracts.Responses;

public class PhoneNumbersResponse
{
    public ICollection<PhoneNumberResponse> PhoneNumbers { get; set; } = new List<PhoneNumberResponse>();
}