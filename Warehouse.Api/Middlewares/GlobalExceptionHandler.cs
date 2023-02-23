using Warehouse.Common.Exceptions;
using DbException = System.Data.Common.DbException;

namespace Warehouse.Api.Middlewares;

public class GlobalExceptionHandler
{
    private readonly RequestDelegate _next;

    
    public GlobalExceptionHandler(RequestDelegate next)
    {
        _next = next;
    }


    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (DbException ex)
        {
        }
        catch (HttpException ex)
        {
        }
        catch (Exception ex)
        {
        }
    }
}