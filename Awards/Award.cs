namespace ScoutApi.Awards;

public class Award
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string Description { get; set; } = string.Empty;
    public ICollection<EarnedAward> EarnedAwards { get; set; }
}