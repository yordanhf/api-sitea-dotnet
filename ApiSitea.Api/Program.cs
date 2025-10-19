using ApiSitea.Api.Mappings;
using ApiSitea.Api.Middlewares;
using ApiSitea.Application.DTOs;
using ApiSitea.Application.Interfaces;
using ApiSitea.Application.Services;
using ApiSitea.Application.Validators;
using ApiSitea.Domain.Interfaces;
using ApiSitea.Infrastructure.Configuration;
using ApiSitea.Infrastructure.Data;
using ApiSitea.Infrastructure.JsonData;
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
//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();
//builder.Logging.AddDebug();
//builder.Logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Information);
//builder.Logging.AddFilter("Microsoft", LogLevel.Warning);
//builder.Logging.AddFilter("System", LogLevel.Warning);

// Serilog setup
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .MinimumLevel.Information() // puedes subirlo a Information en producción
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

// Repositories
builder.Services.AddScoped<IMedicamentoRepository, MedicamentoRepository>();
builder.Services.AddScoped<IAntecedentePPPRepository, AntecedentePPPRepository>();
builder.Services.AddScoped<ICentroRepository, CentroRepository>();
builder.Services.AddScoped<ICClinicaRepository, CClinicaRepository>();
builder.Services.AddScoped<IComorbilidadRepository, ComorbilidadRepository>();
builder.Services.AddScoped<IDiagnosticoRepository, DiagnosticoRepository>();
builder.Services.AddScoped<IFortalezaRepository, FortalezaRepository>();
builder.Services.AddScoped<ITipoInterconsultaRepository, TipoInterconsultaRepository>();
builder.Services.AddScoped<ITipoExamenRepository, TipoExamenRepository>();
builder.Services.AddScoped<IVinculoInstitucionalRepository, VinculoInstitucionalRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IProvinciaRepository, ProvinciaRepository>();
builder.Services.AddScoped<IMunicipioRepository, MunicipioRepository>();

// Services
builder.Services.AddScoped<IMedicamentoService, MedicamentoService>();
builder.Services.AddScoped<IAntecedentePPPService, AntecedentePPPService>();
builder.Services.AddScoped<ICentroService, CentroService>();
builder.Services.AddScoped<ICClinicaService, CClinicaService>();
builder.Services.AddScoped<IComorbilidadService, ComorbilidadService>();
builder.Services.AddScoped<IDiagnosticoService, DiagnosticoService>();
builder.Services.AddScoped<IFortalezaService, FortalezaService>();
builder.Services.AddScoped<ITipoInterconsultaService, TipoInterconsultaService>();
builder.Services.AddScoped<ITipoExamenService, TipoExamenService>();
builder.Services.AddScoped<IVinculoInstitucionalService, VinculoInstitucionalService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IProvinciaService, ProvinciaService>();
builder.Services.AddScoped<IMunicipioService, MunicipioService>();

// Registrar JsonDataProvider como Singleton ya que mantiene caché
builder.Services.AddSingleton<JsonDataProvider>();
builder.Services.Configure<JsonDataSettings>(builder.Configuration.GetSection("JsonDataSettings"));

//Validators
builder.Services.AddScoped<IValidator<MedicamentoCreateDto>, MedicamentoCreateDtoValidator>();
builder.Services.AddScoped<IValidator<MedicamentoUpdateDto>, MedicamentoUpdateDtoValidator>();

builder.Services.AddScoped<IValidator<AntecedentePPPCreateDto>, AntecedentePPPCreateDtoValidator>();
builder.Services.AddScoped<IValidator<AntecedentePPPUpdateDto>, AntecedentePPPUpdateDtoValidator>();

builder.Services.AddScoped<IValidator<CentroCreateDto>, CentroCreateDtoValidator>();
builder.Services.AddScoped<IValidator<CentroUpdateDto>, CentroUpdateDtoValidator>();

builder.Services.AddScoped<IValidator<CClinicaCreateDto>, CClinicaCreateDtoValidator>();
builder.Services.AddScoped<IValidator<CClinicaUpdateDto>, CClinicaUpdateDtoValidator>();

builder.Services.AddScoped<IValidator<ComorbilidadCreateDto>, ComorbilidadCreateDtoValidator>();
builder.Services.AddScoped<IValidator<ComorbilidadUpdateDto>, ComorbilidadUpdateDtoValidator>();

builder.Services.AddScoped<IValidator<DiagnosticoCreateDto>, DiagnosticoCreateDtoValidator>();
builder.Services.AddScoped<IValidator<DiagnosticoUpdateDto>, DiagnosticoUpdateDtoValidator>();

builder.Services.AddScoped<IValidator<FortalezaCreateDto>, FortalezaCreateDtoValidator>();
builder.Services.AddScoped<IValidator<FortalezaUpdateDto>, FortalezaUpdateDtoValidator>();

builder.Services.AddScoped<IValidator<TipoInterconsultaCreateDto>, TipoInterconsultaCreateDtoValidator>();
builder.Services.AddScoped<IValidator<TipoInterconsultaUpdateDto>, TipoInterconsultaUpdateDtoValidator>();

builder.Services.AddScoped<IValidator<TipoExamenCreateDto>, TipoExamenCreateDtoValidator>();
builder.Services.AddScoped<IValidator<TipoExamenUpdateDto>, TipoExamenUpdateDtoValidator>();

builder.Services.AddScoped<IValidator<VinculoInstitucionalCreateDto>, VinculoInstitucionalCreateDtoValidator>();
builder.Services.AddScoped<IValidator<VinculoInstitucionalUpdateDto>, VinculoInstitucionalUpdateDtoValidator>();

builder.Services.AddScoped<IValidator<PacienteCreateDto>, PacienteCreateDtoValidator>();
builder.Services.AddScoped<IValidator<PacienteUpdateDto>, PacienteUpdateDtoValidator>();


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
    c.RoutePrefix = "docs"; // Ahora estará en /docs
    
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
