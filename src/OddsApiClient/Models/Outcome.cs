namespace OddsApiClient.Models;

public class Outcome
{
  
  public string Name { get; set; } = String.Empty;


  public decimal Price { get; set; } = 0;


  public decimal Points { get; set; } = 0;


  public string Description { get; set; } = String.Empty;
}