using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiVenda.Domain.Entities;
using WebApiVenda.Domain.Enums;
using WebApiVenda.Domain.Interfaces;
using WebApiVenda.Infrastructure.Context;

namespace WebApiVenda.Infrastructure.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private ApplicationDbContext _context;

        public VendaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Venda venda)
        {
            _context.Add(venda);
            await _context.SaveChangesAsync();
        }

        public async Task CancelAsync(Venda venda)
        {
            venda.Status = (int)EVendaStatus.Cancelada;
            _context.Update(venda);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Venda>> GetAllAsync()
        {
            return await _context.Vendas.AsNoTracking().ToListAsync();
        }

        public async Task<Venda> GetIdAsync(long? id)
        {
            return await _context.Vendas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Venda venda)
        {
            _context.Update(venda);
            await _context.SaveChangesAsync();
        }
    }
}
