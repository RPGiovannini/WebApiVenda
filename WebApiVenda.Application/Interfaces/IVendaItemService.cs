using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiVenda.Application.DTOs;

namespace WebApiVenda.Application.Interfaces
{
    public interface IVendaItemService
    {
        public Task<IEnumerable<VendaItemDTO>> GetAll();
        public Task<VendaItemDTO> GetId(long? id);
        public Task Add(VendaItemDTO vendaItemDTO);
        public Task Update(VendaItemDTO vendaItemDTO);
        public Task Cancel(VendaItemDTO vendaItemDTO);
    }
}
