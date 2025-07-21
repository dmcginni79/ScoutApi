using ScoutApi.Contracts.Requests;
using ScoutApi.Contracts.Responses;
using ScoutApi.PhoneNumbers;

namespace ScoutApi.Contracts;

public static class PhoneNumberContractMapping
{
    public static PhoneNumber MapToPhoneNumber(this CreatePhoneNumberRequest request)
    {
        return new PhoneNumber
        {
            Id = Guid.NewGuid(),
            GuardianId = request.GuardianId,
            Number = request.Number,
            Type = request.Type,
            Guardian = null // Guardian will be set later if needed
        };
    }
    
    public static PhoneNumberResponse MapToResponse(this PhoneNumber phoneNumber)
    {
        return new PhoneNumberResponse
        {
            Id = phoneNumber.Id,
            Number = phoneNumber.Number,
            Type = phoneNumber.Type,
            GuardianId = phoneNumber.GuardianId
        };
    }

    public static PhoneNumbersResponse MapToResponse(this IEnumerable<PhoneNumber> phoneNumbers)
    {
        return new PhoneNumbersResponse
        {
            PhoneNumbers = phoneNumbers.Select(MapToResponse).ToList()
        };
    }
}