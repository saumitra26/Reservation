using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace RoomReservation.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ArgumentException ex)
        {
            await WriteProblem(context, HttpStatusCode.BadRequest, ex.Message);
        }
        catch (KeyNotFoundException ex)
        {
            await WriteProblem(context, HttpStatusCode.NotFound, ex.Message);
        }
        catch (Exception)
        {
            await WriteProblem(context, HttpStatusCode.InternalServerError,
                "An unexpected error occurred");
        }
    }

    private static async Task WriteProblem(HttpContext context, HttpStatusCode status, string message)
    {
        var problem = new ProblemDetails
        {
            Status = (int)status,
            Title = status.ToString(),
            Detail = message,
            Instance = context.Request.Path
        };

        context.Response.StatusCode = problem.Status.Value;
        context.Response.ContentType = "application/problem+json";
        await context.Response.WriteAsJsonAsync(problem);
    }
}