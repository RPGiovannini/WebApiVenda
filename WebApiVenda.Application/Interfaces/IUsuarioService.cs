using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiVenda.Application.DTOs;

namespace WebApiVenda.Application.Interfaces
{
    public interface IUsuarioService
    {
        public Task<IEnumerable<UsuarioDTO>> GetAll();
        public Task<UsuarioDTO> GetId(long? id);
        public Task Add(UsuarioDTO usuarioDTO);
        public Task Update(UsuarioDTO usuarioDTO);
        public Task Delete(UsuarioDTO usuarioDTO);
    }
}
