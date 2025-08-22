using ProyectoTwin.BaseDatos;
using ProyectoTwin.Services;
using ProyectoTwin.Mappings;
using ProyectoTwin.Repositories;
using ProyectoTwin.Seeding;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de la cadena de conexi�n (ajusta seg�n tu entorno)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Server=(localdb)\\mssqllocaldb;Database=ProyectoTwinDB;Trusted_Connection=True;MultipleActiveResultSets=true";

// Configuraci�n de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

// Registro del contexto de base de datos
builder.Services.AddDbContext<ContextBaseDatos>(options =>
    options.UseSqlServer(connectionString));

// Registro del servicio ComponenteTwinService
builder.Services.AddScoped<IComponenteTwinService, ComponenteTwinService>();

// Registro del repositorio gen�rico
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Registro de AutoMapper
builder.Services.AddAutoMapper(typeof(ComponenteTwinProfile));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Seeding de datos ficticios al iniciar la aplicaci�n
dbSeed(app);

// Habilitar CORS globalmente
app.UseCors("PermitirFrontend");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void dbSeed(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ContextBaseDatos>();
    if (!context.ComponentesTwin.Any())
    {
        var seeder = new DataSeeder();
        var datos = seeder.GenerarComponentes(30); //  se generan 30
        context.ComponentesTwin.AddRange(datos);
        context.SaveChanges();
    }
}
