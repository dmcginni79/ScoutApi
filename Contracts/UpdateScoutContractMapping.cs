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

public static class UpdateScoutContractMapping
{
    public static Scout MapToScout(this UpdateScoutRequest request)
    {
        return new Scout
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            BirthDate = request.BirthDate,
            EarnedRanks = request.EarnedRanks ?? new List<Scout.Rank>(),
            EarnedAwards = request.EarnedAwards ?? new List<EarnedAward>(),
            Guardians = request.Guardians ?? new List<Guardian>(),
        };
    }
}