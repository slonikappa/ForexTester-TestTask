using System.Text.Json.Serialization;

using MongoDB.Driver;

using ProjectMicroservices.Infrastructure.External.UsersMicroservice;

using ProjectsMicroservice.Domain.Core.Entities;
using ProjectsMicroservice.Domain.Core.Options;
using ProjectsMicroservice.Domain.Infrastructure.Interfaces;
using ProjectsMicroservice.Infrastructure.DataAccess.Repositories;
using ProjectsMicroservice.Inrastructure.BusinessLogic.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddScoped<IRepository<UserSettings>, UserSettingsRepository>();
builder.Services.AddScoped<IProjectsRepository, ProjectsRepository>();

builder.Services.AddScoped<IUserSettingsService, UserSettingsService>();
builder.Services.AddScoped<IProjectsService, ProjectsService>();

builder.Services.AddScoped<IUsersMicroservice, UsersMicroserviceClient>();

// Register options
var mongoDbOptionsSection = builder.Configuration.GetSection("Application:MongoDB");
builder.Services.Configure<MongoDbOptions>(mongoDbOptionsSection);

// Database registration
var mongoDbOptions = mongoDbOptionsSection.Get<MongoDbOptions>();

builder.Services.AddSingleton<IMongoClient>(new MongoClient(mongoDbOptions.ConnectionString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
