using Scalar.AspNetCore;
using ProfesionalesAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ProfesionalesAPI.Dto;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin() // Permitir cualquier origen
              .AllowAnyMethod() // Permitir cualquier método (GET, POST, etc.)
              .AllowAnyHeader(); // Permitir cualquier encabezado
    });
});

// Cargar manualmente los archivos de configuración
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                      .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

Console.WriteLine($"Environment: {builder.Environment.EnvironmentName}");


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"Connection String: {connectionString}"); // Depuración

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(connectionString));

// Agregar servicios de controladores
builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings?.Issuer ?? "", // Debe coincidir con el valor en GenerateJwtToken
            ValidAudience = jwtSettings?.Audience ?? "", // Debe coincidir con el valor en GenerateJwtToken
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings?.SecretKey ?? ""))
        };
    });

// Configure OpenAPI
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, _) =>
    {
        document.Info = new()
        {
            Title = "Product Catalog API",
            Version = "v1",
            Description = """
                Modern API for managing product catalogs.
                Supports JSON and XML responses.
                Rate limited to 1000 requests per hour.
                """,
            Contact = new()
            {
                Name = "API Support",
                Email = "api@example.com",
                Url = new Uri("https://example.com/support") // URL válida
            }
        };
        return Task.CompletedTask;
    });
});



var app = builder.Build();

app.UseCors("AllowAll");

app.MapControllers();

// Enable OpenAPI and Scalar
app.MapOpenApi().CacheOutput();
app.MapScalarApiReference();

app.UseAuthentication(); // Habilitar autenticación
app.UseAuthorization(); // Habilitar autorización

// Redirect root to Scalar UI
app.MapGet("/", () => Results.Redirect("/scalar/v1"))
   .ExcludeFromDescription();

app.Run();