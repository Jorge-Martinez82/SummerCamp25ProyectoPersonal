using Microsoft.EntityFrameworkCore;
using ProyectoTwin.BaseDatos;
using ProyectoTwin.DTOs;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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

        public async Task<(List<ComponenteTwinDto> Items, int TotalCount)> GetPagedFilteredAsync(string nombre, string estadoReal, string estadoDigital, int numeroPagina, int tamanoPagina)
        {
            var consulta = _context.ComponentesTwin.AsQueryable();

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                nombre = nombre.Trim();
                consulta = consulta.Where(c => c.Nombre.Contains(nombre));
            }
            if (!string.IsNullOrWhiteSpace(estadoReal))
            {
                estadoReal = estadoReal.Trim();
                consulta = consulta.Where(c => c.EstadoReal == estadoReal);
            }
            if (!string.IsNullOrWhiteSpace(estadoDigital))
            {
                estadoDigital = estadoDigital.Trim();
                consulta = consulta.Where(c => c.EstadoDigital == estadoDigital);
            }

            consulta = consulta.OrderBy(c => c.IdComponente);

            var total = await consulta.CountAsync();
            var items = await consulta.Skip((numeroPagina - 1) * tamanoPagina).Take(tamanoPagina).ToListAsync();
            return (_mapper.Map<List<ComponenteTwinDto>>(items), total);
        }
    }
}
