using FluentValidation;
using ScoutApi.Scouts;

namespace ScoutApi.scouts;

public class ScoutValidator : AbstractValidator<Scout>
{
    public ScoutValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.FirstName)
            .NotEmpty();

        RuleFor(x => x.LastName)
            .NotEmpty();

        RuleFor(x => x.BirthDate)
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow));
    }
}