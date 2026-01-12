using ColoradoDesafio.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColoradoDesafio.Web.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteViewModel>> GetAllAsync();
        Task<ClienteViewModel> GetByIdAsync(int id);
        Task<ClienteViewModel> CreateAsync(ClienteViewModel cliente);
        Task<ClienteViewModel> UpdateAsync(int id, ClienteViewModel cliente);
        Task<bool> DeleteAsync(int id);
    }
}
