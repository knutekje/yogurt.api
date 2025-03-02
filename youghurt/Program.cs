using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Serilog;
using youghurt;
using youghurt.Data;
using youghurt.Repositories;
using youghurt.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Logging.AddConsole().SetMinimumLevel(LogLevel.Debug);
builder.Services.AddSwaggerGen();


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddDbContext<YoghurtDbContext>(options =>
    options.UseSqlite("Data Source=guestexperience.db"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        if (exception is ControllerException)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("A controller error occurred.");
        }
        else if (exception is ServiceException)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("A service error occurred.");
        }
        else if (exception is RepositoryException)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("A repository error occurred.");
        }
    });
});

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();
app.MapControllers();



app.Run();


