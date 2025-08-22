using ProyectoTwin.BaseDatos;
using ProyectoTwin.Services;
using ProyectoTwin.Mappings;
using ProyectoTwin.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la cadena de conexión (ajusta según tu entorno)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Server=(localdb)\\mssqllocaldb;Database=ProyectoTwinDB;Trusted_Connection=True;MultipleActiveResultSets=true";

// Registro del contexto de base de datos
builder.Services.AddDbContext<ContextBaseDatos>(options =>
    options.UseSqlServer(connectionString));

// Registro del servicio ComponenteTwinService
builder.Services.AddScoped<IComponenteTwinService, ComponenteTwinService>();

// Registro del repositorio genérico
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Registro de AutoMapper
builder.Services.AddAutoMapper(typeof(ComponenteTwinProfile));

// Add services to the container.
builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
