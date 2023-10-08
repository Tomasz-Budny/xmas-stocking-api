using System.Net;

namespace xmas_stocking.Api.Exceptions
{
    public sealed class ExceptionToResponseMapper : IExceptionToResponseMapper
    {
        public ExceptionResponse Map(Exception exception)
            => exception switch
            {
                XmasStockingException ex => new ExceptionResponse(new Error(GetErrorCode(ex), ex.Message)
                    , HttpStatusCode.BadRequest),
                _ => new ExceptionResponse(new Error("error", "There was an unexpected error."),
                    HttpStatusCode.InternalServerError)
            };

        private static string GetErrorCode(object exception)
        {
            var type = exception.GetType();
            return type.Name.Replace("Exception", string.Empty);
        }
    }
}
