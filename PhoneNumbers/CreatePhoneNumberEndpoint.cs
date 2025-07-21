using FastEndpoints;
using FluentValidation;
using ScoutApi.Contracts;
using ScoutApi.Contracts.Requests;
using ScoutApi.Contracts.Responses;
using Microsoft.AspNetCore.Http.HttpResults;
using ScoutApi.Data;
using ScoutApi.Guardians;
using ScoutApi.Scouts;

namespace ScoutApi.PhoneNumbers;

public class CreatePhoneNumberEndpoint 
    : Endpoint<CreatePhoneNumberRequest, Results<Created<PhoneNumberResponse>, NotFound<string>, BadRequest>>
{
    private readonly IPhoneNumberService _phoneNumberService;
    private readonly IGuardianService _guardianService;

    public CreatePhoneNumberEndpoint(IPhoneNumberService phoneNumberService, IGuardianService guardianService)
    {
        _phoneNumberService = phoneNumberService;
        _guardianService = guardianService;
    }

    public override void Configure()
    {
        Post("/phonenumber");
        AllowAnonymous();
    }
    
    public override async Task<Results<Created<PhoneNumberResponse>, NotFound<string>, BadRequest>> 
        ExecuteAsync(CreatePhoneNumberRequest req, CancellationToken ct)
    {
        var newPhoneNumber = req.MapToPhoneNumber();
        var guardian = await _guardianService.GetByIdAsync(req.GuardianId);

        if (guardian == null)
        {
            return TypedResults.NotFound($"Guardian with ID {req.GuardianId} not found.");
        }

        var result = await _phoneNumberService.CreateAsync(newPhoneNumber);
        
        var response = result.Match<IResult>(
            _ => TypedResults.Created($"/phonenumber/{newPhoneNumber.Id}", newPhoneNumber.MapToResponse()),
            failed => TypedResults.BadRequest(failed.MapToResponse()));
        
        return response switch
        {
            Created<PhoneNumberResponse> success => success,
            BadRequest badRequest => badRequest,
            _ => throw new Exception("Impossible")
        };
        
        //var response = result.Match<Results<Created<PhoneNumberResponse>, NotFound<string>, BadRequest>>(
        //     success => TypedResults.Created($"/phonenumber/{success.Id}", success.MapToResponse()),
        //     failed => TypedResults.BadRequest(failed.MapToResponse()));
        //
        // return response;
    }
}