namespace Warehouse.Common.Exceptions;

public class HttpException : Exception
{
    public HttpException(string message) : base(message) { }
    
    public HttpException(string message, Exception ex) : base(message, ex) { }
}