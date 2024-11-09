using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiVenda.Domain.Entities;
using WebApiVenda.Domain.Interfaces;
using WebApiVenda.Infrastructure.Context;

namespace WebApiVenda.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> DeleteAsync(Cliente cliente)
        {
            cliente.Ativo = false;
            _context.Update(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.AsNoTracking().Where(x => x.Ativo).ToListAsync();
        }

        public async Task<Cliente> GetIdAsyc(long? id)
        {
            return await _context.Clientes.AsNoTracking().Where(x => x.Ativo).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Cliente> UpdateAsync(Cliente cliente)
        {
            _context.Update(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }
    }
}
