using System.Reflection;

namespace ScoutApi.Scouts;

public static class RankExtensions
{
    public static string GetDisplayName(this Scout.Rank rank)
    {
        var memberInfo = typeof(Scout.Rank).GetMember(rank.ToString()).FirstOrDefault();
        var attribute = memberInfo?.GetCustomAttribute<Scout.RankDisplayNameAttribute>();
        return attribute?.DisplayName ?? rank.ToString();
    }
}