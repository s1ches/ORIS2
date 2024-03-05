using System.Net;
using PokemonAPI.Exceptions;

namespace PokemonAPI.Handlers;

/// <summary>
/// Сlass responsible for handling exceptions
/// </summary>
public static class ExceptionHandler
{
    public static async Task HandleAsync(Exception exception, HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        HandleException(exception as dynamic, context);   
        await context.Response.WriteAsync(exception.Message);
    }

    private static void HandleException(PokemonNotFoundException _, HttpContext context)
    {
        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
    }

    private static void HandleException(HttpRequestException _, HttpContext context)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    }

    private static void HandleException(NullReferenceException _, HttpContext context)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        
    }

    private static void HandleException(ArgumentException _, HttpContext context)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    }


}