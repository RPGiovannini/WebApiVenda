using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiVenda.Application.DTOs;

namespace WebApiVenda.Application.Interfaces
{
    public interface IVendaService
    {
        public Task<IEnumerable<VendaDTO>> GetAll();
        public Task<VendaDTO> GetId(long? id);
        public Task Add(VendaDTO vendaDTO);
        public Task Update(VendaDTO vendaDTO);
        public Task Cancel(VendaDTO vendaDTO);
        public Task FinalizeSale(VendaDTO vendaDTO);
    }
}
