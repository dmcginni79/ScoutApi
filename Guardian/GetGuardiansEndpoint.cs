using FastEndpoints;
using ScoutApi.Contracts;
using ScoutApi.Contracts.Responses;
using ScoutApi.Guardians;

namespace ScoutApi.Endpoints;

public class GetGuardiansEndpoint : EndpointWithoutRequest<List<GuardianResponse>>
{
    private readonly IGuardianService _guardianService;

    public GetGuardiansEndpoint(IGuardianService guardianService)
    {
        _guardianService = guardianService;
    }

    public override void Configure()
    {
        Get("/guardians");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var guardians = await _guardianService.GetAllAsync();
        var response = guardians.Select(g => g.MapToResponse()).ToList();
        await SendAsync(response, cancellation: ct);
    }
}