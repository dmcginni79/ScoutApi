using ScoutApi.Awards;
using ScoutApi.Entities;
using ScoutApi.Ranks;

namespace ScoutApi.Contracts.Requests;

public class CreateScoutRequest
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public ICollection<EarnedRank> EarnedRanks { get; set; }
    public ICollection<EarnedAward> EarnedAwards { get; set; } 
    public DateOnly BirthDate { get; set; }
    public ICollection<Guardian> Guardians { get; set; }
}