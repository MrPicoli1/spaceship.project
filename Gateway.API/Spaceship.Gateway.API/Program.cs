using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Spaceship.Gateway.Data.RabbitMq;
using Spaceship.Gateway.Data.Repositories;
using Spaceship.Gateway.Domain.Profiles;
using Spaceship.Gateway.Extensions.Http;
using Spaceship.Gateway.Services.Interfaces;
using Spaceship.Gateway.Services.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
    //.AddJsonOptions(x =>x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gateway API", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


var connectionStringSQL = builder.Configuration.GetConnectionString("MySQL");

builder.Services.AddDbContext<SpaceshipMySQLContext>(opts =>
{
    opts.UseMySql(connectionStringSQL, ServerVersion.AutoDetect(connectionStringSQL));
});

builder.Services.Configure<SpaceshipMongoDbSettings>(
    builder.Configuration.GetSection("MissionMongoDatabase"));


builder.Services.AddTransient<IUserService,UserService>();
builder.Services.AddTransient<ISpaceshipService, SpaceshipService>();
builder.Services.AddTransient<IMissionService, MissionService>();
builder.Services.AddAutoMapper(typeof(SpaceshipProfiles));
builder.Services.AddScoped<HttpClientExtensions>();
builder.Services.AddSingleton<IMessageProducer, MQPRoducer>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
