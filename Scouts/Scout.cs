
using ScoutApi.Awards;
using ScoutApi.Guardians;

namespace ScoutApi.Scouts;

public class Scout
{
    public enum Rank
    {
        Lion,
        Tiger,
        Wolf,
        Bear,
        Webelos,
        ArrowOfLight,
        Tenderfoot,
        SecondClass,
        FirstClass,
        Star,
        Life,
        Eagle
    }

    
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public ICollection<Rank> EarnedRanks { get; set; }
    public ICollection<EarnedAward> EarnedAwards { get; set; } 
    public required DateOnly BirthDate { get; set; }
    public ICollection<Guardian> Guardians { get; set; }
    
    // Helper property to easily get the current rank
    public Rank? CurrentRank => EarnedRanks.LastOrDefault();
}