using FastEndpoints;
using ScoutApi.Contracts;
using ScoutApi.Contracts.Responses;
using ScoutApi.Guardians;

namespace ScoutApi.Endpoints;

public class GetGuardianEndpoint : Endpoint<GuardianResponse, GuardianResponse>
{
    private readonly IGuardianService _guardianService;

    public GetGuardianEndpoint(IGuardianService guardianService)
    {
        _guardianService = guardianService;
    }

    public override void Configure()
    {
        Get("/guardian/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GuardianResponse req, CancellationToken ct)
    {
        var guardian = await _guardianService.GetByIdAsync(req.Id);

        if (guardian is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var response = guardian.MapToResponse(); // Assumes a mapping method exists
        await SendAsync(response, cancellation: ct);
    }
}