using OddsApiClient;
using OddsApiClient.Requests;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var oddsClient = new OddsApiClient.OddsApiClient(new OddsApiClientOptions
{
    BaseUrl = app.Configuration.GetValue<string>("OddsApiClient:BaseUrl"),
    ApiKey = app.Configuration.GetValue<string>("OddsApiClient:ApiKey")
});

app.UseHttpsRedirection();

app.MapGet("/sports", () =>
{
    var sports = oddsClient.Sports.RetrieveSportsAsync(new RetrieveSportsRequest { All = true }).Result.Sports;

    return sports;
})
.WithName("GetSports")
.WithOpenApi();

app.MapGet("/odds/sport", (string sportKey) =>
{
    var odds = oddsClient.Events.RetrieveSportOddsAsync(new RetrieveSportOddsRequest { Sport = sportKey }).Result.Odds;


    return odds;
})
.WithName("GetNflOdds")
.WithOpenApi();

app.Run();
