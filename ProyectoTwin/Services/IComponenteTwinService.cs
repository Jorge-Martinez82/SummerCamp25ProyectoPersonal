using ProyectoTwin.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoTwin.Services
{
    public interface IComponenteTwinService
    {
        Task<IEnumerable<ComponenteTwinDto>> GetAllAsync();
        Task<ComponenteTwinDto> GetByIdAsync(int id);
        Task<(IEnumerable<ComponenteTwinDto> Items, int TotalCount)> GetPagedFilteredAsync(string nombre, string estadoReal, string estadoDigital, int numeroPagina, int tamanoPagina);
    }
}
