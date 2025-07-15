using FluentValidation.Results;
using ScoutApi.PhoneNumbers;
using ScoutApi.Validation;

namespace ScoutApi.Contracts;
using ScoutApi.Contracts.Requests;
using ScoutApi.Contracts.Responses;
using ScoutApi.Guardians;

public static class GuardianContractMapping
{
    public static GuardianResponse MapToResponse(this Guardian guardian)
    {
        return new GuardianResponse
        {
            Id = guardian.Id,
            FirstName = guardian.FirstName,
            LastName = guardian.LastName,
            Email = guardian.Email,
            PhoneNumbers = guardian.PhoneNumbers?.ToList() ?? new List<PhoneNumber>(),
            IsPrimaryGuardian = guardian.IsPrimaryGuardian
        };
    }

    public static GuardiansResponse MapToResponse(this IEnumerable<Guardian> guardians)
    {
        return new GuardiansResponse
        {
            Guardians = guardians.Select(MapToResponse).ToList()
        };
    }
}