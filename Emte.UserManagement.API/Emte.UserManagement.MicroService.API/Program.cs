using Microsoft.Extensions.Configuration;
using Emte.Core.API;
using Emte.UserManagement.API;
using Emte.UserManagement.API.Configuration;
using Emte.UserManagement.API.DataAccess;
using Emte.UserManagement.API.Extensions;
using Emte.UserManagement.API.Middlewares;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Emte.Core.JWTAuth;
using Emte.Core.Authentication.Contract;

var builder = WebApplication.CreateBuilder(args);
var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile(@"appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($@"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

var Configuration = configurationBuilder.Build();
// Add services to the container.
builder.Services.Configure<AppConfig>(Configuration);

var appConfig = new AppConfig();
Configuration.Bind(appConfig);
builder.Services.AddTransient<IAuthConfig>((p) => appConfig.Authentication!);
builder.Services.InitializeJWTAuthentication(appConfig.Authentication!);
builder.Services.AddControllers();
builder.Services.RegisterServiceCollection(Configuration);
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

app.UseTenantIdentifier();

app.UseAuthorization();

app.MapControllers();

app.Run();

