using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankApp.Core.CrossCuttingConcerns.Exceptions.Types;
using BankApp.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
using System.Text.Json;

namespace BankApp.Core.CrossCuttingConcerns.Exceptions.Handlers;

public class HttpExceptionHandler : ExceptionHandler
{
    private HttpResponse? _response;
    public HttpResponse Response
    {
        get => _response ?? throw new ArgumentNullException(nameof(_response));
        set => _response = value;
    }

    protected override Task HandleException(BusinessException businessException)
    {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        var details = new BusinessProblemDetails(businessException.Message);
        return Response.WriteAsync(JsonSerializer.Serialize(details));
    }

    protected override Task HandleException(ValidationException validationException)
    {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        var details = new BankApp.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails.ValidationProblemDetails(validationException.Errors);
        return Response.WriteAsync(JsonSerializer.Serialize(details));
    }

    protected override Task HandleException(AuthorizationException authorizationException)
    {
        Response.StatusCode = StatusCodes.Status401Unauthorized;
        var details = new AuthorizationProblemDetails(authorizationException.Message);
        return Response.WriteAsync(JsonSerializer.Serialize(details));
    }

    protected override Task HandleException(Exception exception)
    {
        Response.StatusCode = StatusCodes.Status500InternalServerError;
        var details = new InternalServerErrorProblemDetails(exception.Message);
        return Response.WriteAsync(JsonSerializer.Serialize(details));
    }
} 