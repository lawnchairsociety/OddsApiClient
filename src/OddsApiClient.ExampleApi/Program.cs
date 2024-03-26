using OddsApiClient;
using OddsApiClient.Requests;
using OddsApiClient.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Odds API client to services
builder.Services.AddOddsApiClient(o =>
    {
        o.BaseUrl = builder.Configuration.GetValue<string>("OddsApiClient:BaseUrl");
        o.ApiKey = builder.Configuration.GetValue<string>("OddsApiClient:ApiKey");
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/sports", (IOddsApiClient oddsClient) =>
{
    var sports = oddsClient.Sports.RetrieveSportsAsync(new RetrieveSportsRequest { All = true }).Result.Sports;

    return sports;
})
.WithName("GetSports")
.WithOpenApi();

app.MapGet("/odds/sport", (IOddsApiClient oddsClient, string sportKey) =>
{
    var odds = oddsClient.Events.RetrieveSportOddsAsync(new RetrieveSportOddsRequest { Sport = sportKey }).Result.Odds;


    return odds;
})
.WithName("GetNflOdds")
.WithOpenApi();

app.Run();
