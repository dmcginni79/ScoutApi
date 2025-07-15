using ScoutApi.Awards;
using ScoutApi.Entities;

namespace ScoutApi.Ranks;

public class Rank : Award
{
    public int Order { get; set; }
    public ICollection<EarnedRank> EarnedRanks { get; set; }
}