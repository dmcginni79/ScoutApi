using ScoutApi.Awards;
using ScoutApi.Guardians;
using ScoutApi.Ranks;

namespace ScoutApi.Contracts.Responses;

public class ScoutResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public ICollection<EarnedRank> EarnedRanks { get; set; }
    public ICollection<EarnedAward> EarnedAwards { get; set; } 
    public DateOnly BirthDate { get; set; }
    public ICollection<Guardian> Guardians { get; set; }
}