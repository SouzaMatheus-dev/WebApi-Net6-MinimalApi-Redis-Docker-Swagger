using FrameworkChallenge.Domain;
using Microsoft.Extensions.Caching.Distributed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.InstanceName = "RedisCache";
    options.Configuration = "localhost:6379,abortConnect=false,connectTimeout=30000,responseTimeout=30000";
});

var app = builder.Build();

app.MapGet("/v1/divisores", (int number, IDistributedCache distributedCache) =>
{
    //string CalculatorDividersCacheKey = "CalculatorDividers";

    global::FrameworkChallenge.Domain.CalculatorDividers _calculate = new();
    var dividers = _calculate.Calculate(number);

    //distributedCache.SetString(CalculatorDividersCacheKey, "Teste Framework");

    return Results.Created($"/v1/divisores/{number}", dividers);
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();