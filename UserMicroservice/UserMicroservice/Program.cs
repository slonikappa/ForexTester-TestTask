using Microsoft.EntityFrameworkCore;

using UserMicroservice.Infrastructure.DataAccess.DB;
using UserMicroservice.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connection config
var connectionOptionsSection = builder.Configuration.GetSection("Application:Connection");
builder.Services.Configure<ConnectionOptions>(connectionOptionsSection);

var connectionOptions = connectionOptionsSection.Get<ConnectionOptions>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionOptions.DbConnectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
