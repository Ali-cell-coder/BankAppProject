using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace BankApp.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

public class NotFoundProblemDetails : ProblemDetails
{
    public NotFoundProblemDetails(string detail)
    {
        Title = "Not Found";
        Detail = detail;
        Status = StatusCodes.Status404NotFound;
        Type = "https://example.com/probs/not-found";
    }
} 