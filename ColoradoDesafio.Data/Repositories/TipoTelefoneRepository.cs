using ColoradoDesafio.Data.Context;
using ColoradoDesafio.Domain.Entities;
using ColoradoDesafio.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColoradoDesafio.Data.Repositories
{
    public class TipoTelefoneRepository : ITipoTelefoneRepository
    {
        private readonly ColoradoDbContext _context;

        public TipoTelefoneRepository(ColoradoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoTelefone>> GetAllAsync()
        {
            return await _context.TiposTelefone
                .Where(t => t.Ativo)
                .OrderBy(t => t.Descricao)
                .ToListAsync();
        }

        public async Task<TipoTelefone> GetByIdAsync(int id)
        {
            return await _context.TiposTelefone.FindAsync(id);
        }
    }
}
