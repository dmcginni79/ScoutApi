using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ScoutApi.Contracts;
using ScoutApi.Contracts.Requests;
using ScoutApi.Contracts.Responses;
using ScoutApi.Validation;

namespace ScoutApi.Scouts;

public class UpdateScoutByIdEndpoint 
    : Endpoint<UpdateScoutRequest, Results<Accepted<ScoutResponse>, NotFound, BadRequest>>
{
    private readonly IScoutService _scoutService;
    
    public UpdateScoutByIdEndpoint(IScoutService scoutService)
    {
        _scoutService = scoutService;
    }

    public override void Configure()
    {
        Put("/scout/{id}");
        AllowAnonymous();
    }

    public override async Task<Results<Accepted<ScoutResponse>, NotFound, BadRequest>>
        ExecuteAsync(UpdateScoutRequest req, CancellationToken ct)
    {
        var id = Guid.Parse(Route<string>("id"));
        var scout = await _scoutService.GetByIdAsync(id);
        
        if (scout != null)
        {
            scout = req.MapToScout();
        }
        else
        {
            return TypedResults.NotFound();
        }
        
        var scoutUpdate = req.MapToScout();
        scout.BirthDate = scoutUpdate.BirthDate;
        scout.FirstName = scoutUpdate.FirstName;
        scout.LastName = scoutUpdate.LastName;
        scout.EarnedAwards = scoutUpdate.EarnedAwards;
        scout.EarnedRanks = scoutUpdate.EarnedRanks;
        scout.Guardians = scoutUpdate.Guardians;
        
        var results = await _scoutService.UpdateAsync(scout);
        
        var response = results.Match<IResult>(
            _ => TypedResults.Accepted($"/scout/{scout.Id}", scout.MapToResponse()),
            failed => TypedResults.BadRequest(failed.MapToResponse()));
        
        return response switch
        {
            Accepted<ScoutResponse> success => success,
            BadRequest badRequest => badRequest,
            _ => throw new Exception("Impossible")
        };
    }
}