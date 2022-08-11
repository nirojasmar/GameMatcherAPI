// -------------------------------------- Temporal Database Testing ------------------------- //
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

string password = File.ReadAllText(@"M:\Docs\Developer\Utils\password.txt"); // Temporal
var settings = MongoClientSettings.FromConnectionString("mongodb+srv://admin:" + password + "@maincluster.vwz4kig.mongodb.net/?retryWrites=true&w=majority");
settings.ServerApi = new ServerApi(ServerApiVersion.V1);
var client = new MongoClient(settings);
List<string> databases = client.ListDatabaseNames().ToList(); // TODO: Relocate to Services

// -------------------------------------- ------------------------- ------------------------- //
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "GameMatcher API",
        Description = "An ASP.NET Core Web API that provides all the data for GameMatcher",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "License",
            Url = new Uri("https://example.com/license")
        }
    });
});

var app = builder.Build();

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
