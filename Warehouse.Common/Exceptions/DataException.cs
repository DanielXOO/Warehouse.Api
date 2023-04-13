namespace Warehouse.Common.Exceptions;

public sealed class DataException : Exception
{
    public DataException(string message) : base(message) { }
    
    public DataException(string message, Exception ex) : base(message, ex) { }
}