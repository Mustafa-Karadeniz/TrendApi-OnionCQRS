
using Newtonsoft.Json;

namespace TrendApi.Application.Exceptions;

internal class ExceptionModel : ErrorsStatusCode
{
    public IEnumerable<string> Errors { get; set; }
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}

public class ErrorsStatusCode
{
    public int StatusCode { get; set; }
}
