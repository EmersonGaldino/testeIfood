using System;

namespace ifood.test.galdino.domain.Utils.Exceptions
{
    public class RequestException : Exception
    {
        public RequestException(int statusCode, string message)
        {
            StatusCode = statusCode;
        }
        public int StatusCode { get; }
    }
}
