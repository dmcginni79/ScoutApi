using FastEndpoints;
using ScoutApi.Contracts;
using ScoutApi.Contracts.Requests;
using ScoutApi.Contracts.Responses;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ScoutApi.Scouts;

public class CreateScoutEndpoint 
    : Endpoint<CreateScoutRequest, Results<Created<ScoutResponse>, BadRequest>>
{
    private readonly IScoutService _scoutService;

    public CreateScoutEndpoint(IScoutService scoutService)
    {
        _scoutService = scoutService;
    }

    public override void Configure()
    {
        Post("/scout");
        AllowAnonymous();
    }
    
    public override async Task<Results<Created<ScoutResponse>, BadRequest>> 
        ExecuteAsync(CreateScoutRequest req, CancellationToken ct)
    {
        var scout = req.MapToScout();
        var result = await _scoutService.CreateAsync(scout);
        var response = result.Match<IResult>(
            _ => TypedResults.Created($"/scout/{scout.Id}", scout.MapToResponse()),
            failed => TypedResults.BadRequest(failed.MapToResponse()));

        return response switch
        {
            Created<ScoutResponse> success => success,
            BadRequest badRequest => badRequest,
            _ => throw new Exception("Impossible")
        };
    }
}