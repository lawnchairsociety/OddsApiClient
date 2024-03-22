namespace OddsApiClient.Tests;

public class ResponseLoader
{
  private static readonly string ResponseDirectory = Path.GetFullPath(
    Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Responses"));
  
  public static string Load(string responseFileName)
  {
    var responseFilePath = Path.Combine(ResponseDirectory, responseFileName);
    return File.ReadAllText(responseFilePath);
  }
}