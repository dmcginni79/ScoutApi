using FluentValidation.Results;
using ScoutApi.Contracts.Responses;
using ScoutApi.Validation;

namespace ScoutApi.Contracts;

public static class ContractMappingHelpers
{
    public static ValidationFailureResponse MapValidationFailures(this IEnumerable<ValidationFailure> validationFailures)
    {
        return new ValidationFailureResponse
        {
            Errors = validationFailures.Select(x => new ValidationResponse
            {
                PropertyName = x.PropertyName,
                Message = x.ErrorMessage
            })
        };
    }

    public static ValidationFailureResponse MapValidationFailed(this ValidationFailed failed)
    {
        return new ValidationFailureResponse
        {
            Errors = failed.Errors.Select(x => new ValidationResponse
            {
                PropertyName = x.PropertyName,
                Message = x.ErrorMessage
            })
        };
    }
}