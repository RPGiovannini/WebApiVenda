using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiVenda.Domain.Entities;

namespace WebApiVenda.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> GetIdAsyc(long? id);
        Task<Usuario> CreateAsync(Usuario cliente);
        Task<Usuario> UpdateAsync(Usuario cliente);
        Task<Usuario> DeleteAsync(Usuario cliente);
        Task<Usuario> GetEmailAsyc(string email);
    }
}
