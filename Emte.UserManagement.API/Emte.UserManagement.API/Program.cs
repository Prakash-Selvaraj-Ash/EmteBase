using Emte.Core.API;
using Emte.UserManagement.API;
using Emte.UserManagement.API.Configuration;
using Emte.UserManagement.API.DataAccess;
using Emte.UserManagement.API.Extensions;
using Emte.UserManagement.API.Middlewares;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile(@"appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($@"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

var Configuration = configurationBuilder.Build();
// Add services to the container.
builder.Services.Configure<AppConfig>(Configuration);
builder.Services.AddControllers();
builder.Services.RegisterServiceCollection(Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc(opts => { opts.EnableEndpointRouting = false; });

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();
app.UseTenantIdentifier();
var appConfig = app.Services.GetService<IOptionsMonitor<AppConfig>>();
app.AddSwaggerWeb<AppConfig>(appConfig!, "EMTE.UserManagementAPI");
app.UseMvc();

app.Run();

