using FluentValidation;

namespace ScoutApi.Guardians;

public class GuardianValidator : AbstractValidator<Guardian>
{
    public GuardianValidator()
    {
        RuleFor(g => g.FirstName)
            .NotEmpty().WithMessage("First name is required.");

        RuleFor(g => g.LastName)
            .NotEmpty().WithMessage("Last name is required.");

        RuleFor(g => g.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(g => g.PhoneNumbers)
            .NotEmpty().WithMessage("At least one phone number is required.");

        RuleForEach(g => g.PhoneNumbers)
            .SetValidator(new PhoneNumberValidator());
    }
}