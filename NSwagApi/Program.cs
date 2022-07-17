using System.Net;
using System.Net.Mime;
using Sample;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<ISampleApiClient, SampleApiClient>((provider, client) =>
{
    client.DefaultRequestHeaders.Accept.Add(new(MediaTypeNames.Application.Json));
    client.DefaultRequestVersion = HttpVersion.Version20;
    client.Timeout = TimeSpan.FromMinutes(1);
    client.BaseAddress = new("https://localhost:7198");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();