using FastEndpoints;
using ScoutApi.Contracts;
using ScoutApi.Contracts.Requests;
using ScoutApi.Contracts.Responses;
using ScoutApi.Guardians;

namespace ScoutApi.Endpoints;

public class GetGuardiansByScoutIdEndpoint : Endpoint<GetGuardiansByScoutIdRequest, List<GuardianResponse>>
{
    private readonly IGuardianService _guardianService;

    public GetGuardiansByScoutIdEndpoint(IGuardianService guardianService)
    {
        _guardianService = guardianService;
    }

    public override void Configure()
    {
        Get("/guardians/by-scout/{scoutId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetGuardiansByScoutIdRequest req, CancellationToken ct)
    {
        var guardians = await _guardianService.GetByScoutIdAsync(req.ScoutId);
        var response = guardians.Select(g => g.MapToResponse()).ToList();
        await SendAsync(response, cancellation: ct);
    }
}