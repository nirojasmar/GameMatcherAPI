// -------------------------------------- Temporal Database Testing ------------------------- //
using MongoDB.Driver;
using MongoDB.Bson;

var builder = WebApplication.CreateBuilder(args);

string password = File.ReadAllText(@"M:\Docs\Developer\Utils\password.txt"); // Temporal
var settings = MongoClientSettings.FromConnectionString("mongodb+srv://admin:" + password + "@maincluster.vwz4kig.mongodb.net/?retryWrites=true&w=majority");
settings.ServerApi = new ServerApi(ServerApiVersion.V1);
var client = new MongoClient(settings);
List<string> databases = client.ListDatabaseNames().ToList(); // TODO: Relocate to Services

// -------------------------------------- ------------------------- ------------------------- //
// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
