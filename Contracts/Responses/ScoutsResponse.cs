namespace ScoutApi.Contracts.Responses;

public class ScoutsResponse
{
    public required IEnumerable<ScoutResponse> Items { get; init; } = Enumerable.Empty<ScoutResponse>();
}