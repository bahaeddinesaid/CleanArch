using Application.DependancyInjection;
using Infrastructure.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Product.API.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigurePersistenceServices(builder.Configuration);

//Initialize Logger
//Log.Logger = new LoggerConfiguration()
var _logger = new LoggerConfiguration()
.ReadFrom.Configuration(builder.Configuration)
    // Add console (Sink) as logging target
    /*.WriteTo.Console()
// Write logs to a file for warning and logs with a higher severity
// Logs are written in JSON
.WriteTo.File(new JsonFormatter(),
"important-logs.json",
restrictedToMinimumLevel: LogEventLevel.Warning)

// Add a log file that will be replaced by a new log file each day
.WriteTo.File("all-daily-.logs",
rollingInterval: RollingInterval.Day)

    // Set default minimum log level
    .MinimumLevel.Information()*/
    .CreateLogger();
//builder.Logging.AddSerilog(Log.Logger);
builder.Logging.AddSerilog(_logger);

try
{
    Log.Information("Application Starting.");
    //CreateHostBuilder(args).Build().Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "The Application failed to start.");
}
finally
{
    Log.CloseAndFlush();
}


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "clean Arch product API",
        Description = "An ASP.NET Core Web API for managing Products ",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = " Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = " License",
            Url = new Uri("https://example.com/license")
        }
    });
});

builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
