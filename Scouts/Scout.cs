
using System.Reflection;
using System.Text.Json.Serialization;
using ScoutApi.Awards;
using ScoutApi.Guardians;

namespace ScoutApi.Scouts;

public class Scout
{
    public enum Rank
    {
        [RankDisplayName("Lion")]
        Lion = 0,
        [RankDisplayName("Tiger")]
        Tiger = 1,
        [RankDisplayName("Wolf")]
        Wolf = 2,
        [RankDisplayName("Bear")]
        Bear = 3,
        [RankDisplayName("Webelos")]
        Webelos = 4,
        [RankDisplayName("Arrow of Light")]
        ArrowOfLight = 5,
        [RankDisplayName("Tenderfoot")]
        Tenderfoot = 6,
        [RankDisplayName("Second Class")]
        SecondClass = 7,
        [RankDisplayName("First Class")]
        FirstClass = 8,
        [RankDisplayName("Star")]
        Star = 9,
        [RankDisplayName("Life")]
        Life = 10,
        [RankDisplayName("Eagle")]
        Eagle = 11
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public class RankDisplayNameAttribute : Attribute
    {
        public string DisplayName { get; }
        public RankDisplayNameAttribute(string displayName) => DisplayName = displayName;
    }
    
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public ICollection<Rank> EarnedRanks { get; set; } = new List<Rank>();
    public ICollection<EarnedAward> EarnedAwards { get; set; } = new List<EarnedAward>();
    public required DateOnly BirthDate { get; set; }
    //public int Age => DateTime.Now.Year - BirthDate.Year - (DateTime.Now.DayOfYear < BirthDate.DayOfYear ? 1 : 0);
    public ICollection<Guardian> Guardians { get; set; } = new List<Guardian>();

    public int Age
    {
        get
        {
            return DateTime.Now.Year - BirthDate.Year - (DateTime.Now.DayOfYear < BirthDate.DayOfYear ? 1 : 0);
        }
    }
    // Helper property to easily get the current rank
    public Rank? CurrentRank
    {
        get
        {
            var allRanks = Enum.GetValues<Rank>();
            return allRanks
                .Where(r => !EarnedRanks.Contains(r))
                .OrderBy(r => (int)r)
                .FirstOrDefault();
        }
    }
}
