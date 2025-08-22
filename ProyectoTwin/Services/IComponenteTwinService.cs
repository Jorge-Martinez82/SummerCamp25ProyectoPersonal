using ProyectoTwin.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoTwin.Services
{
    public interface IComponenteTwinService
    {
        Task<IEnumerable<ComponenteTwinDto>> GetAllAsync();
        Task<ComponenteTwinDto> GetByIdAsync(int id);
        // M�todos para crear, actualizar y eliminar se agregar�n cuando se implemente el repository
    }
}
