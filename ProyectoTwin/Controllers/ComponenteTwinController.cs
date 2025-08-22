using Microsoft.AspNetCore.Mvc;
using ProyectoTwin.Services;
using ProyectoTwin.DTOs;
using Microsoft.Extensions.Logging;


namespace ProyectoTwin.Controllers
{
    [ApiController]
    [Route("api/ComponenteTwin")]
    public class ComponenteTwinController : ControllerBase
    {
        private readonly IComponenteTwinService _service;
        private readonly ILogger<ComponenteTwinController> _logger;

        public ComponenteTwinController(IComponenteTwinService service, ILogger<ComponenteTwinController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComponenteTwinDto>>> GetAll()
        {
            _logger.LogInformation("Obteniendo todos los componentes twin");
            try
            {
                var componentes = await _service.GetAllAsync();
                _logger.LogInformation("Se obtuvieron {Count} componentes twin", componentes?.Count() ?? 0);
                return Ok(componentes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los componentes twin");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComponenteTwinDto>> GetById(int id)
        {
            _logger.LogInformation("Obteniendo componente twin con id {Id}", id);
            try
            {
                var dto = await _service.GetByIdAsync(id);
                if (dto == null)
                {
                    _logger.LogWarning("No se encontró el componente twin con id {Id}", id);
                    return NotFound();
                }
                _logger.LogInformation("Componente twin con id {Id} encontrado", id);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el componente twin con id {Id}", id);
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
