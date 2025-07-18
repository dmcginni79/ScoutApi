using ScoutApi.Awards;
using ScoutApi.Guardians;
using ScoutApi.Scouts;

namespace ScoutApi.Contracts.Responses;

public class ScoutResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public ICollection<string> EarnedRanks { get; set; } = new List<string>();
    public ICollection<EarnedAward> EarnedAwards { get; set; } = new List<EarnedAward>();
    public DateOnly BirthDate { get; set; }
    public int Age { get; init; } 
    public ICollection<Guardian> Guardians { get; set; } = new List<Guardian>();
    public string? CurrentRank { get; init; } 
}