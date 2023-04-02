using Microsoft.EntityFrameworkCore;

using UserMicroservice.Domain.Core.Entities;
using UserMicroservice.Domain.Infastructure.Interfaces;
using UserMicroservice.Infrastructure.BusinessLogic.Services;
using UserMicroservice.Infrastructure.DataAccess;
using UserMicroservice.Infrastructure.DataAccess.DB;
using UserMicroservice.Infrastructure.DataAccess.Repositories;
using UserMicroservice.Domain.Core.Options;
using System.Text.Json.Serialization;
using UserMicroservice.Application.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connection config
var connectionOptionsSection = builder.Configuration.GetSection("Application:Connection");
builder.Services.Configure<ConnectionOptions>(connectionOptionsSection);

var connectionOptions = connectionOptionsSection.Get<ConnectionOptions>();

//Dependencies
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionOptions.DbConnectionString));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IRepository<Subscription>, SubscriptionsRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IApplicationMapper, ApplicationMapper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
