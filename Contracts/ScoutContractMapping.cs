using ScoutApi.Awards;
using ScoutApi.Contracts.Requests;
using ScoutApi.Contracts.Responses;
using ScoutApi.Guardians;
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
            EarnedRanks = request.EarnedRanks ?? new List<Scout.Rank>(),
            EarnedAwards = request.EarnedAwards ?? new List<EarnedAward>(),
            Guardians = request.Guardians ?? new List<Guardian>()
        };
    }

    public static ScoutResponse MapToResponse(this Scout scout)
    {
        var allRanks = Enum.GetValues<Scout.Rank>();
        var nextRank = scout.EarnedRanks.Any() 
            ? allRanks.FirstOrDefault(r => (int)r > (int)scout.EarnedRanks.Max(), Scout.Rank.Eagle)
            : Scout.Rank.Lion;
        
        return new ScoutResponse
        {
            Id = scout.Id,
            FirstName = scout.FirstName,
            LastName = scout.LastName,
            BirthDate = scout.BirthDate,
            Age = scout.Age,
            EarnedRanks = scout.EarnedRanks?.Select(r => r.ToString()).ToList() 
                          ?? new List<string>(),
            EarnedAwards = scout.EarnedAwards ?? new List<EarnedAward>(),
            Guardians = scout.Guardians ?? new List<Guardian>(),
            CurrentRank = nextRank == Scout.Rank.Eagle && scout.EarnedRanks.Contains(Scout.Rank.Eagle) 
                ? Scout.Rank.Eagle.ToString()
                : nextRank.ToString()

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