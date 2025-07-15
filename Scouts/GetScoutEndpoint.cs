using FastEndpoints;
using ScoutApi.Contracts;
using ScoutApi.Contracts.Responses;

namespace ScoutApi.Scouts;

public class GetScoutEndpoint : EndpointWithoutRequest<ScoutResponse>
{
    private readonly IScoutService _scoutService;
    
    public GetScoutEndpoint(IScoutService scoutService)
    {
        _scoutService = scoutService;
    }

    public override void Configure()
    {
        Get("/scout/{id}");
        AllowAnonymous();
    }

    public override async Task<ScoutResponse> ExecuteAsync(CancellationToken ct)
    {
        var id = Guid.Parse(Route<string>("id"));
        var scout = await _scoutService.GetByIdAsync(id);
        return scout.MapToResponse();
    }
}