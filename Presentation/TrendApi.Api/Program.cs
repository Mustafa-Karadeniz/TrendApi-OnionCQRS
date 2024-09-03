using TrendApi.Persistence;
using TrendApi.Mapper;
using TrendApi.Application.Exceptions;
using YoutubeApi.Application;
using YoutubeApi.Infrastructure;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var env = builder.Environment;

builder.Configuration
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddCustomMapper();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "Trend API", Version = "v1", Description = " Trend API Swagger Client." });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name    =  "Authorization",
        Type    =  SecuritySchemeType.ApiKey,
        Scheme  =  "Bearer",
        BearerFormat = "Jwt",
        In =  ParameterLocation.Header,
        Description = "'Bearer' yazarak boþlup býrakýp daha sonra Token'ý girebilirsiniz \r\n\r\n Örneðin: \"Bearer x8G5dH1jY9LmW4K2bQZ7qT6pV3RrCzNvP0aXoJfUcIsEyMhDlkFBgAtuSiwO\""
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<String>()
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

app.ConfigureExceptionHandlingMiddleware();
app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
