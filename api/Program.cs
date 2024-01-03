using Microsoft.AspNetCore.Mvc;
using shared;

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

app.UseHttpsRedirection();

var currencies = new[]
{
    "USD", "GBP", "EUR", "TRY", "GEL", "UAH", "AUD", "CAD", "CNY", "EGP", "JPY", "NOK", "RUB"
}; 

app.MapGet("/currency", ([FromHeader(Name = "Authorization")]string customHeader) =>
{
    var random = Random.Shared.Next(0, currencies.Length);

    Console.WriteLine($"Authorization: {customHeader}");

    switch (random)
    {
        case 0:
            return Results.Unauthorized();
        case 1:
            return Results.Forbid();
        case 2:
            return Results.BadRequest();
        case 3:
            return Results.StatusCode(429);
        case 4:
            return Results.StatusCode(500);
        case 5:
            return Results.StatusCode(503);
        default:
        {
            var currency =  Enumerable.Range(1, 5).Select(index =>
                new Currency
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    (decimal)Random.Shared.NextDouble(),
                    currencies[Random.Shared.Next(currencies.Length)]
                ))
                .ToArray();
            return Results.Ok(currency);
        }
    }
})
.WithName("GetCurrency")
.WithOpenApi();

app.Run();

