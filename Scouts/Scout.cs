
using ScoutApi.Awards;
using ScoutApi.Entities;
using ScoutApi.Ranks;

namespace ScoutApi.Scouts;

public class Scout
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public ICollection<EarnedRank> EarnedRanks { get; set; }
    public ICollection<EarnedAward> EarnedAwards { get; set; } 
    public required DateOnly BirthDate { get; set; }
    public ICollection<Guardian> Guardians { get; set; }
}