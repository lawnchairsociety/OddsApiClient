namespace OddsApiClient.Exceptions;

/// <summary>
/// Exception representing an unknown failure.
/// </summary>
public class OddsApiClientException
  : Exception
{
  public OddsApiClientException(string message)
    : base(message) { }

  public OddsApiClientException(string message, Exception innerException)
    : base(message, innerException) { }
}

/// <summary>
/// Exception representing a HTTP 401 - Unauthorized response,
/// </summary>
public class OddsApiClientUnauthorizedException
  : OddsApiClientException
{
  public OddsApiClientUnauthorizedException(string message)
    : base(message) { }

  public OddsApiClientUnauthorizedException(string message, Exception innerException)
    : base(message, innerException) { }
}

/// <summary>
/// Exception representing a HTTP 404 - Not Found response,
/// </summary>
public class OddsApiClientNotFoundException
  : OddsApiClientException
{
  public OddsApiClientNotFoundException(string message)
    : base(message) { }

  public OddsApiClientNotFoundException(string message, Exception innerException)
    : base(message, innerException) { }
}

/// <summary>
/// Exception representing a HTTP 422 - Unprocessable Content response.
/// </summary>
public class OddsApiClientInvalidParameterException
  : OddsApiClientException
{
  public OddsApiClientInvalidParameterException(string message)
    : base(message) { }

  public OddsApiClientInvalidParameterException(string message, Exception innerException)
    : base(message, innerException) { }
}

/// <summary>
/// Exception representing a HTTP 429 - Too Many Requests response.
/// </summary>
public class OddsApiClientTooManyRequestsException
  : OddsApiClientException
{
  public OddsApiClientTooManyRequestsException(string message)
    : base(message) { }

  public OddsApiClientTooManyRequestsException(string message, Exception innerException)
    : base(message, innerException) { }
}

/// <summary>
/// Exception representing a HTTP 500 - Internal Error response.
/// </summary>
public class OddsApiClientInternalErrorException
  : OddsApiClientException
{
  public OddsApiClientInternalErrorException(string message)
    : base(message) { }

  public OddsApiClientInternalErrorException(string message, Exception innerException)
    : base(message, innerException) { }
}