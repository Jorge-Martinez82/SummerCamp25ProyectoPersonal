using Microsoft.EntityFrameworkCore;
using ProyectoTwin.BaseDatos;
using ProyectoTwin.DTOs;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoTwin.Services
{
    public class ComponenteTwinService : IComponenteTwinService
    {
        private readonly ContextBaseDatos _context;
        private readonly IMapper _mapper;

        public ComponenteTwinService(ContextBaseDatos context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ComponenteTwinDto>> GetAllAsync()
        {
            var entidades = await _context.ComponentesTwin.ToListAsync();
            return _mapper.Map<IEnumerable<ComponenteTwinDto>>(entidades);
        }

        public async Task<ComponenteTwinDto> GetByIdAsync(int id)
        {
            var componente = await _context.ComponentesTwin.FindAsync(id);
            return componente == null ? null : _mapper.Map<ComponenteTwinDto>(componente);
        }
    }
}
