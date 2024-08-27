namespace TrendApi.Application.Base;

public class BaseExceptions : ApplicationException
{
    public BaseExceptions() { }
    public BaseExceptions( string mesage) : base( mesage ) { } 
}
