﻿using System.Net;
using System.Net.Http.Headers;
using OddsApiClient.Exceptions;
using RestSharp;

namespace OddsApiClient;

internal static class RestSharpExtensions
{
  public static OddsApiClientException BuildExceptionFromResponse(this RestClient client, RestResponse response)
  {
    var message = response.Content ?? "Error communicating with the Odds API";

    if (response.ErrorException is not null
      && response.ErrorException is not HttpRequestException)
    {
      return new OddsApiClientException(message, response.ErrorException);
    }

    return response.StatusCode switch
    {
      HttpStatusCode.Unauthorized => new OddsApiClientUnauthorizedException(message),
      HttpStatusCode.NotFound => new OddsApiClientNotFoundException(message),
      HttpStatusCode.UnprocessableEntity => new OddsApiClientInvalidParameterException(message),
      HttpStatusCode.TooManyRequests => new OddsApiClientTooManyRequestsException(message),
      HttpStatusCode.InternalServerError => new OddsApiClientInternalErrorException(message),
      _ => new OddsApiClientException(message)
    };
  }
}