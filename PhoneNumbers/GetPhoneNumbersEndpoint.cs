using FastEndpoints;
using ScoutApi.Contracts;
using ScoutApi.Contracts.Responses;
using ScoutApi.PhoneNumbers;

namespace ScoutApi.Endpoints;

public class GetPhoneNumberEndpoint : EndpointWithoutRequest<List<PhoneNumberResponse>>
{
    private readonly IPhoneNumberService _phoneNumberService;

    public GetPhoneNumberEndpoint(IPhoneNumberService phoneNumberService)
    {
        _phoneNumberService = phoneNumberService;
    }

    public override void Configure()
    {
        Get("/phonenumbers");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var phoneNumbers = await _phoneNumberService.GetAllAsync();
        var response = phoneNumbers.Select(g => g.MapToResponse()).ToList();
        await SendAsync(response, cancellation: ct);
    }
}