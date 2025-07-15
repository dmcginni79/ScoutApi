
using ScoutApi.Scouts;

namespace ScoutApi.Awards;

public class EarnedAward
{
    public Guid Id { get; set; }
    public required Guid ScoutId { get; set; }
    public Scout Scout { get; set; } = null!;
    public required Guid AwardId { get; set; }
    public Award Award { get; set; } = null!;
    public required DateOnly DateEarned { get; set; }
}