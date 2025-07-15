using FluentValidation;
using ScoutApi.PhoneNumbers;

public class PhoneNumberValidator : AbstractValidator<PhoneNumber>
{
    public PhoneNumberValidator()
    {
        RuleFor(p => p.Number)
            .NotEmpty().WithMessage("Phone number is required.");

        RuleFor(p => p.Type)
            .NotEmpty().WithMessage("Phone number type is required.");
    }
}