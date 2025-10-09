using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace BankApp.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

public class AuthorizationProblemDetails : ProblemDetails
{
    public AuthorizationProblemDetails(string detail)
    {
        Title = "Authorization Error";
        Detail = detail;
        Status = StatusCodes.Status401Unauthorized;
        Type = "https://example.com/probs/authorization";
    }
} 