using ProyectoTwin.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoTwin.Services
{
    public interface IComponenteTwinService
    {
        Task<IEnumerable<ComponenteTwinDto>> GetAllAsync();
        Task<ComponenteTwinDto> GetByIdAsync(int id);
        // Métodos para crear, actualizar y eliminar se agregarán cuando se implemente el repository
    }
}
