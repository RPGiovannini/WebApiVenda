using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiVenda.Domain.Entities;

namespace WebApiVenda.Domain.Interfaces
{
    public interface IVendaItemRepository
    {
        public Task<IEnumerable<VendaItem>> GetAllAsync();
        public Task<VendaItem> GetIdAsync(long? id);
        public Task CreateAsync(VendaItem vendaItem);
        public Task UpdateAsync(VendaItem vendaItem);
        public Task CancelAsync(VendaItem vendaItem);
        public Task<IEnumerable<VendaItem>> GetByVendaAsync(long? idVenda);
    }
}
