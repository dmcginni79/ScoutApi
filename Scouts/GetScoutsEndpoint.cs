using FastEndpoints;
using ScoutApi.Contracts;
using ScoutApi.Contracts.Responses;

namespace ScoutApi.Scouts;

public class GetScoutsEndpoint : EndpointWithoutRequest<ScoutsResponse>
{
    private readonly IScoutService _scoutService;
    
    public GetScoutsEndpoint(IScoutService scoutService)
    {
        _scoutService = scoutService;
    }

    public override void Configure()
    {
        Get("/scouts");
        AllowAnonymous();
    }

    public override async Task<ScoutsResponse> ExecuteAsync(CancellationToken ct)
    {
        var scouts = await _scoutService.GetAllAsync();
        return scouts.MapToResponse();
    }
}