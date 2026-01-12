using ColoradoDesafio.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColoradoDesafio.Web.Services
{
    public interface ITipoTelefoneService
    {
        Task<IEnumerable<TipoTelefoneViewModel>> GetAllAsync();
    }
}
