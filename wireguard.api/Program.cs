using wireguard.api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseSwagger();
app.UseSwaggerUI();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();


await generatefile.generate();

await ProcessHelper.ExecuteWgShow();

string largeText = @"
  _  __ _       
 | |/ _(_)      
 | | |_ _  __ _  
 | |  _| |/ _` | 
 | | | | | (_| | 
 |_/_| |_|\__, | 
          __/ | 
         |___/  
";

Console.WriteLine("----------------------------------");

Console.WriteLine(largeText);

Console.WriteLine("----------------------------------");

await ProcessHelper.StatusWireguard(true,"wg0");
await ProcessHelper.StatusWireguard(false, "wg0");
app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
