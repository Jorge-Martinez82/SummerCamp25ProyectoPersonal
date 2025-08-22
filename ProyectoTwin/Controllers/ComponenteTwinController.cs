using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoTwin.BaseDatos;
using ProyectoTwin.DTOs;


namespace ProyectoTwin.Controllers
{
    [ApiController]
    [Route("api/ComponenteTwin")]
    public class ComponenteTwinController : ControllerBase
    {
        private readonly ContextBaseDatos _context;

        public ComponenteTwinController(ContextBaseDatos context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComponenteTwinDto>>> GetAll()
        {
            var componentes = await _context.ComponentesTwin
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
            return Ok(componentes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComponenteTwinDto>> GetById(int id)
        {
            var componente = await _context.ComponentesTwin.FindAsync(id);
            if (componente == null)
                return NotFound();
            var dto = new ComponenteTwinDto
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
            return Ok(dto);
        }

    }
}
