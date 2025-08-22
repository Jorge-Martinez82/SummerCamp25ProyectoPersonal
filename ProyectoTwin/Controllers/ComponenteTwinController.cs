using Microsoft.AspNetCore.Mvc;
using ProyectoTwin.Services;
using ProyectoTwin.DTOs;


namespace ProyectoTwin.Controllers
{
    [ApiController]
    [Route("api/ComponenteTwin")]
    public class ComponenteTwinController : ControllerBase
    {
        private readonly IComponenteTwinService _service;

        public ComponenteTwinController(IComponenteTwinService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComponenteTwinDto>>> GetAll()
        {
            var componentes = await _service.GetAllAsync();
            return Ok(componentes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComponenteTwinDto>> GetById(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null)
                return NotFound();
            return Ok(dto);
        }
    }
}
