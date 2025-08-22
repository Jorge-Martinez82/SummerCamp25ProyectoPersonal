using Microsoft.EntityFrameworkCore;
using ProyectoTwin.BaseDatos;
using ProyectoTwin.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTwin.Services
{
    public class ComponenteTwinService : IComponenteTwinService
    {
        private readonly ContextBaseDatos _context;

        public ComponenteTwinService(ContextBaseDatos context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ComponenteTwinDto>> GetAllAsync()
        {
            return await _context.ComponentesTwin
                .Select(c => new ComponenteTwinDto
                {
                    IdComponente = c.IdComponente,
                    Nombre = c.Nombre,
                    TipoDatos = c.TipoDatos,
                    EstadoReal = c.EstadoReal,
                    EstadoDigital = c.EstadoDigital,
                    UltimaActualizacion = c.UltimaActualizacion,
                    IndicadorSostenibilidad = c.IndicadorSostenibilidad,
                    MantenimientoProgramado = c.MantenimientoProgramado
                })
                .ToListAsync();
        }

        public async Task<ComponenteTwinDto> GetByIdAsync(int id)
        {
            var componente = await _context.ComponentesTwin.FindAsync(id);
            if (componente == null) return null;
            return new ComponenteTwinDto
            {
                IdComponente = componente.IdComponente,
                Nombre = componente.Nombre,
                TipoDatos = componente.TipoDatos,
                EstadoReal = componente.EstadoReal,
                EstadoDigital = componente.EstadoDigital,
                UltimaActualizacion = componente.UltimaActualizacion,
                IndicadorSostenibilidad = componente.IndicadorSostenibilidad,
                MantenimientoProgramado = componente.MantenimientoProgramado
            };
        }
    }
}
