namespace Warehouse.Api.Models.Response;

public class ErrorResponseModel
{
    public int StatusCode { get; set; }

    public string Message { get; set; }
    
    public string Details { get; set; }

    public ErrorResponseModel InnerError { get; set; }
}