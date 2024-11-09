using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiVenda.Application.DTOs;

namespace WebApiVenda.Application.Interfaces
{
    public interface IClienteService
    {
        public Task<IEnumerable<ClienteDTO>> GetAll();
        public Task<ClienteDTO> GetId(long? id);
        public Task Add(ClienteDTO clienteDTO);
        public Task Update(ClienteDTO clienteDTO);
        public Task Delete(ClienteDTO clienteDTO);
    }
}