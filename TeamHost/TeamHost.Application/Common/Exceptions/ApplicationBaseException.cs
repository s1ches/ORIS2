using System.Net;

namespace TeamHost.Application.Common.Exceptions;

public class ApplicationBaseException(string message, HttpStatusCode statusCode) : Exception(message)
{
    private HttpStatusCode _statusCode = statusCode;
}