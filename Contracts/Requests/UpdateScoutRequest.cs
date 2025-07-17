using ScoutApi.Awards;
using ScoutApi.Guardians;
using ScoutApi.Scouts;

namespace ScoutApi.Contracts.Requests;

public class UpdateScoutRequest
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public ICollection<Scout.Rank> EarnedRanks { get; set; }
    public ICollection<EarnedAward> EarnedAwards { get; set; } 
    public DateOnly BirthDate { get; set; }
    public ICollection<Guardian> Guardians { get; set; }
    public Scout.Rank? CurrentRank { get; set; } // Optional, can be null if not set
}