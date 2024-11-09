using WebApiVenda.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiVenda.Application.Interfaces
{
    public interface IProdutoService
    {
        public Task<IEnumerable<ProdutoDTO>> GetAll();
        public Task<ProdutoDTO> GetId(long? id);
        public Task Add(ProdutoDTO produtoDTO);
        public Task Update(ProdutoDTO produtoDTO);
        public Task Delete(ProdutoDTO produtoDTO);
    }
}
