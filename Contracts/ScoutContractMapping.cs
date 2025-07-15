using ScoutApi.Awards;
using ScoutApi.Contracts.Requests;
using ScoutApi.Contracts.Responses;
using ScoutApi.Guardians;
using ScoutApi.Ranks;
using ScoutApi.Scouts;
using FluentValidation.Results;
using ScoutApi.Contracts.Requests;
using ScoutApi.Contracts.Responses;
using ScoutApi.Validation;

namespace ScoutApi.Contracts;

public static class ScoutContractMapping
{
    public static Scout MapToScout(this CreateScoutRequest request)
    {
        return new Scout
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            BirthDate = request.BirthDate,
            EarnedRanks = request.EarnedRanks ?? new List<EarnedRank>(),
            EarnedAwards = request.EarnedAwards ?? new List<EarnedAward>(),
            Guardians = request.Guardians ?? new List<Guardian>()
        };
    }

    public static ScoutResponse MapToResponse(this Scout scout)
    {
        return new ScoutResponse
        {
            Id = scout.Id,
            FirstName = scout.FirstName,
            LastName = scout.LastName,
            BirthDate = scout.BirthDate,
            EarnedRanks = scout.EarnedRanks ?? new List<EarnedRank>(),
            EarnedAwards = scout.EarnedAwards ?? new List<EarnedAward>(),
            Guardians = scout.Guardians ?? new List<Guardian>()
        };
    }

    public static ScoutsResponse MapToResponse(this IEnumerable<Scout> scouts)
    {
        return new ScoutsResponse
        {
            Items = scouts.Select(MapToResponse)
        };
    }
    
    public static ValidationFailureResponse MapToResponse(this IEnumerable<ValidationFailure> validationFailures)
        => ContractMappingHelpers.MapValidationFailures(validationFailures);

    public static ValidationFailureResponse MapToResponse(this ValidationFailed failed)
        => ContractMappingHelpers.MapValidationFailed(failed);
}