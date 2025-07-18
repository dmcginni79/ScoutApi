using FluentValidation.Results;
using ScoutApi.PhoneNumbers;
using ScoutApi.Scouts;
using ScoutApi.Validation;

namespace ScoutApi.Contracts;
using ScoutApi.Contracts.Requests;
using ScoutApi.Contracts.Responses;
using ScoutApi.Guardians;

public static class GuardianContractMapping
{
    public static Guardian MapToGuardian(this CreateGuardianRequest request)
    {
        return new Guardian
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PhoneNumbers = request.PhoneNumbers?.ToList() ?? new List<PhoneNumber>(),
            IsPrimaryGuardian = request.IsPrimaryGuardian,
            Scouts = request.Scouts?.ToList() ?? new List<Scout>(),
        };
    }
    
    public static GuardianResponse MapToResponse(this Guardian guardian)
    {
        return new GuardianResponse
        {
            Id = guardian.Id,
            FirstName = guardian.FirstName,
            LastName = guardian.LastName,
            Email = guardian.Email,
            PhoneNumbers = guardian.PhoneNumbers?.ToList() ?? new List<PhoneNumber>(),
            IsPrimaryGuardian = guardian.IsPrimaryGuardian,
            Scouts = guardian.Scouts?.Select(s => s.MapToResponse()).ToList() ?? new List<ScoutResponse>()
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