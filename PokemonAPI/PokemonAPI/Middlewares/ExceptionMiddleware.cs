using PokemonAPI.Handlers;

namespace PokemonAPI.Middlewares;

public class ExceptionMiddleware: IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await ExceptionHandler.HandleAsync(exception, context);
        }
    }
}