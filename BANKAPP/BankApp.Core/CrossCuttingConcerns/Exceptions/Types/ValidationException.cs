using FluentValidation.Results;

namespace BankApp.Core.CrossCuttingConcerns.Exceptions.Types;

public class ValidationException : Exception
{
    public IEnumerable<ValidationFailure> Errors { get; }

    public ValidationException(IEnumerable<ValidationFailure> errors) : base("Validation error occurred")
    {
        Errors = errors;
    }
} 