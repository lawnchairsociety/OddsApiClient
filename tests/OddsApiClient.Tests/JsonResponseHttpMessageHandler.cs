using System.Text;

namespace OddsApiClient.Tests;

public class JsonResponseHttpMessageHandler
  : HttpMessageHandler
{
    private readonly StringContent _jsonContent;

    public JsonResponseHttpMessageHandler(string jsonResponse)
    {
        this._jsonContent = new StringContent(jsonResponse, Encoding.UTF8, "application/json");
    }

    public HttpRequestMessage? Request { get; private set; }
    public HttpResponseMessage? Response { get; private set; }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var response = new HttpResponseMessage
        {
            RequestMessage = request,
            Content = this._jsonContent
        };
        response.Headers.Add("X-Requests-Used", "13");
        response.Headers.Add("X-Requests-Remaining", "87");

        this.Request = request;
        this.Response = response;

        return Task.FromResult(response);
    }
}
