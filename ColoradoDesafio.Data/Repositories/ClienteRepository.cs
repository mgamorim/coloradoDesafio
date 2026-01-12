using ColoradoDesafio.Data.Context;
using ColoradoDesafio.Domain.Entities;
using ColoradoDesafio.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColoradoDesafio.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ColoradoDbContext _context;

        public ClienteRepository(ColoradoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes
                .Include(c => c.Telefones)
                .OrderByDescending(c => c.DataInformacao)
                .ToListAsync();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _context.Clientes
                .Include(c => c.Telefones)
                .FirstOrDefaultAsync(c => c.CodigoCliente == id);
        }

        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            cliente.DataInformacao = System.DateTime.Now;
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> UpdateAsync(Cliente cliente)
        {
            cliente.DataInformacao = System.DateTime.Now;
            _context.Entry(cliente).State = EntityState.Modified;
            
            var existingTelefones = await _context.Telefones
                .Where(t => t.CodigoCliente == cliente.CodigoCliente)
                .ToListAsync();
            
            _context.Telefones.RemoveRange(existingTelefones);
            
            if (cliente.Telefones != null && cliente.Telefones.Any())
            {
                foreach (var telefone in cliente.Telefones)
                {
                    telefone.CodigoCliente = cliente.CodigoCliente;
                    telefone.NumeroTelefone = 0;
                }
                _context.Telefones.AddRange(cliente.Telefones);
            }

            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return false;
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Clientes.AnyAsync(c => c.CodigoCliente == id);
        }
    }
}
