using System.Net;

namespace xmas_stocking.Api.Exceptions
{
    public sealed record Error(string Code, string Message);
    public sealed record ExceptionResponse(Error Error, HttpStatusCode StatusCode);
}
