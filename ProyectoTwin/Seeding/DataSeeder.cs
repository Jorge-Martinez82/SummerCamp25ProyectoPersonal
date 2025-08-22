using Bogus;
using ProyectoTwin.Entidades;
using System;
using System.Collections.Generic;

namespace ProyectoTwin.Seeding
{
    public class DataSeeder
    {
        public List<ComponenteTwin> GenerarComponentes(int cantidad)
        {
            var tiposDatos = new[] { "Sensor Medioambiental", "Infraestructura", "Sistema Movilidad" };
            var estadosReal = new[] { "Activo", "Operativo", "En servicio", "En prueba" };
            var estadosDigital = new[] { "Sincronizado", "Desactualizado", "En Error" };
            var indicadoresSostenibilidad = new[] { "Bajo impacto", "Medio impacto", "Alta eficiencia", "Energía renovable", "Fomenta movilidad sostenible" };
            var tiposNombre = new[] { "Sensor", "Estación", "Punto de Recarga", "Sistema", "Nodo", "Dispositivo" };
            var tiposDatosNombre = new[] { "Calidad Aire", "Ruido", "Temperatura", "Energía Solar", "Transporte Público", "Monitoreo Tráfico" };

            var faker = new Faker<ComponenteTwin>()
                .RuleFor(c => c.IdComponente, f => 0) // EF Core asigna el Id
                .RuleFor(c => c.Nombre, f => $"{f.PickRandom(tiposNombre)} {f.PickRandom(tiposDatosNombre)} #{f.Random.Number(1, 50)}")
                .RuleFor(c => c.TipoDatos, f => f.PickRandom(tiposDatos))
                .RuleFor(c => c.EstadoReal, f => f.PickRandom(estadosReal))
                .RuleFor(c => c.EstadoDigital, f => f.PickRandom(estadosDigital))
                .RuleFor(c => c.UltimaActualizacion, f => f.Date.Recent(10))
                .RuleFor(c => c.IndicadorSostenibilidad, f => f.PickRandom(indicadoresSostenibilidad))
                .RuleFor(c => c.MantenimientoProgramado, f => f.Random.Bool(0.3f));

            return faker.Generate(cantidad);
        }
    }
}
