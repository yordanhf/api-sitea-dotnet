using ApiSitea.Api.Mappings;
using ApiSitea.Api.Middlewares;
using ApiSitea.Application.Interfaces;
using ApiSitea.Application.Services;
using ApiSitea.Domain.Interfaces;
using ApiSitea.Infrastructure.Data;
using ApiSitea.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// ==================================================
// LOGGING CONFIGURATION
// ==================================================
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Information);
builder.Logging.AddFilter("Microsoft", LogLevel.Warning);
builder.Logging.AddFilter("System", LogLevel.Warning);

// Serilog setup
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/api-sitea-.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// ==================================================
// CONTROLLERS + FLUENTVALIDATION
// ==================================================
builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

// Registrar validadores automáticamente desde el ensamblado de Application
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

// Habilitar reglas de validación en Swagger
builder.Services.AddFluentValidationRulesToSwagger();

// ==================================================
// AUTHORIZATION & AUTHENTICATION
// ==================================================
builder.Services.AddAuthorization();
builder.Services.AddAuthentication();

// ==================================================
// AUTOMAPPER
// ==================================================
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// ==================================================
// DATABASE (SQLite)
// ==================================================

var dataFolder = Path.Combine(AppContext.BaseDirectory, "Sqlite");
Directory.CreateDirectory(dataFolder);
var dbPath = Path.Combine(dataFolder, "apisitea.db");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

// ==================================================
// DEPENDENCY INJECTION
// ==================================================
builder.Services.AddScoped<IMedicamentoRepository, MedicamentoRepository>();
builder.Services.AddScoped<IMedicamentoService, MedicamentoService>();

// ==================================================
// SWAGGER
// ==================================================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Sitea",
        Version = "v1",
        Description = "API para gestión de Consulta TEA y Neurodesarrollo"
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
        options.IncludeXmlComments(xmlPath);
});

// ==================================================
// APP BUILD + PIPELINE
// ==================================================
var app = builder.Build();

app.UseSerilogRequestLogging();
app.UseMiddleware<ExceptionMiddleware>();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiSitea v1");
    c.RoutePrefix = string.Empty; // Swagger en la raíz (opcional)
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

// ==================================================
// ERROR HANDLING
// ==================================================
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/error");
}

// ==================================================
// APPLY MIGRATIONS ON STARTUP
// ==================================================
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();  
    
    var backupPath = dbPath + ".bak";
    
    // Crea un respaldo antes de migrar
    if (File.Exists(dbPath))
    {
        File.Copy(dbPath, backupPath, true);
        Console.WriteLine($"...Backup creado: {backupPath}");
    }
    db.Database.ExecuteSqlRaw("PRAGMA journal_mode=WAL;");
    db.Database.Migrate();
}

// ==================================================
// RUN
// ==================================================
app.Run();
