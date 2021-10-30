using System;
using System.Net;

namespace BulkBuilder.Application.Common.Exceptions
{
    public class HttpException : Exception
    {
        public HttpException(HttpStatusCode code, string message = null)
            : base(message)
        {
            Code = code;
        }

        public HttpStatusCode Code { get; }
    }
}
