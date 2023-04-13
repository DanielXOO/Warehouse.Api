using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Microsoft.AspNetCore.WebUtilities;
using Warehouse.Api.Models.Response;
using Warehouse.Common.Exceptions;

using DbException = System.Data.Common.DbException;
using ILogger = Serilog.ILogger;

namespace Warehouse.Api.Middlewares;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    private readonly ILogger _logger;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger logger)
    {
        _next = next;
        _logger = logger;
    }


    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (DbException ex)
        {
            _logger.Error(ex, ex.Message);
            
            var error = HandleError(ex, StatusCodes.Status500InternalServerError);
            await SendErrorResponse(context, error);
        }
        catch (BadRequestException ex)
        {
            _logger.Error(ex, ex.Message);
            
            var error = HandleError(ex, StatusCodes.Status400BadRequest);
            await SendErrorResponse(context, error);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, ex.Message);
            
            var error = HandleError(ex, StatusCodes.Status500InternalServerError);
            await SendErrorResponse(context, error);
        }
    }
    
    private static ErrorResponseModel HandleError(Exception ex, int statusCode)
    {
        var errorResponse = new ErrorResponseModel
        {
            StatusCode = statusCode,
            Message =  ReasonPhrases.GetReasonPhrase(statusCode),
            Details = ex.Message
        };
        
        if (ex.InnerException != null)
        {

            errorResponse.InnerError = HandleError(ex.InnerException, statusCode);
        }
        
        return errorResponse;
    }
    
    private static async Task SendErrorResponse(HttpContext context, ErrorResponseModel errorResponse)
    {
        var options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        };
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = errorResponse.StatusCode;
        var jsonResponse = JsonSerializer.Serialize(errorResponse, options);
        
        await context.Response.WriteAsync(jsonResponse);
    }
}