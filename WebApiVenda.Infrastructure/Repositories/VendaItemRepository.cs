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
    public class VendaItemRepository : IVendaItemRepository
    {
        private ApplicationDbContext _context;
        public VendaItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task CancelAsync(VendaItem vendaItem)
        {
            vendaItem.Ativo = false;
            _context.Update(vendaItem);
            return _context.SaveChangesAsync();
        }

        public Task CreateAsync(VendaItem vendaItem)
        {
            _context.Add(vendaItem);
            return _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<VendaItem>> GetAllAsync()
        {
            return await _context.VendaItems.AsNoTracking().ToListAsync();
        }

        public async  Task<VendaItem> GetIdAsync(long? id)
        {
           return await _context.VendaItems.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateAsync(VendaItem vendaItem)
        {
            _context.Update(vendaItem);
            return _context.SaveChangesAsync();
        }
    }
}
