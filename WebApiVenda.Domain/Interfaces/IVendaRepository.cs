using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiVenda.Domain.Entities;

namespace WebApiVenda.Domain.Interfaces
{
    public interface IVendaRepository
    {
        public Task<IEnumerable<Venda>> GetAllAsync();
        public Task<Venda> GetIdAsync(long? id);
        public Task CreateAsync(Venda venda);
        public Task UpdateAsync(Venda venda);
        public Task CancelAsync(Venda venda);
    }
}
