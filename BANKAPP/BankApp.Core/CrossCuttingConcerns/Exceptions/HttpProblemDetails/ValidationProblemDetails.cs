using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using FluentValidation.Results;

namespace BankApp.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

public class ValidationProblemDetails : ProblemDetails
{
    public IEnumerable<ValidationFailure> Errors { get; }

    public ValidationProblemDetails(IEnumerable<ValidationFailure> errors)
    {
        Title = "Validation Error";
        Status = StatusCodes.Status400BadRequest;
        Type = "https://example.com/probs/validation";
        Errors = errors;
    }
} 