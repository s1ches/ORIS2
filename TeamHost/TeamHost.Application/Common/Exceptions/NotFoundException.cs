using System.Net;

namespace TeamHost.Application.Common.Exceptions;

public class NotFoundException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    : ApplicationBaseException(message, statusCode);