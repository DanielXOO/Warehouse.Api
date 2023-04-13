namespace Warehouse.Common.Exceptions;

public sealed class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message) { }
    
    public BadRequestException(string message, Exception ex) : base(message, ex) { }
}