using ColoradoDesafio.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColoradoDesafio.Domain.Interfaces
{
    public interface ITipoTelefoneRepository
    {
        Task<IEnumerable<TipoTelefone>> GetAllAsync();
        Task<TipoTelefone> GetByIdAsync(int id);
    }
}
