using ScoutApi.Scouts;

namespace ScoutApi.Ranks;

public class EarnedRank
{
    public Guid Id { get; set; }
    public required Guid ScoutId { get; set; }
    public Scout Scout { get; set; } = null!;
    public required Guid RankId { get; set; }
    public Rank Rank { get; set; } = null!;
    public required DateOnly DateEarned { get; set; }
}