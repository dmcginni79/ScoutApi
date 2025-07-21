using FastEndpoints;
using FluentValidation;
using ScoutApi.Contracts;
using ScoutApi.Contracts.Requests;
using ScoutApi.Contracts.Responses;
using Microsoft.AspNetCore.Http.HttpResults;
using ScoutApi.Data;
using ScoutApi.Scouts;
using ScoutApi.Validation;

namespace ScoutApi.Guardians;

public class CreateGuardianEndpoint 
    : Endpoint<CreateGuardianRequest, Results<Created<GuardianResponse>, NotFound<string>, BadRequest>>
{
    private readonly IGuardianService _guardianService;
    private readonly IScoutService _scoutService;

    public CreateGuardianEndpoint(IGuardianService guardianService, IScoutService scoutService)
    {
        _guardianService = guardianService;
        _scoutService = scoutService;
    }

    public override void Configure()
    {
        Post("/guardian");
        AllowAnonymous();
    }
    
    public override async Task<Results<Created<GuardianResponse>, NotFound<string>, BadRequest>> 
        ExecuteAsync(CreateGuardianRequest req, CancellationToken ct)
    {
        var guardian = req.MapToGuardian();
        var scout = await _scoutService.GetByIdAsync(req.ScoutId);
        
        if (scout == null)
        {
            return TypedResults.NotFound($"Scout with ID {req.ScoutId} not found.");
        }
        guardian.Scouts.Add(scout);
        var result = await _guardianService.CreateAsync(guardian);
        var response = result.Match<IResult>(
            _ => TypedResults.Created($"/guardian/{guardian.Id}", guardian.MapToResponse()),
            failed => TypedResults.BadRequest(failed.MapToResponse()));

        return response switch
        {
            Created<GuardianResponse> success => success,
            BadRequest badRequest => badRequest,
            _ => throw new Exception("Impossible")
        };
    }
}