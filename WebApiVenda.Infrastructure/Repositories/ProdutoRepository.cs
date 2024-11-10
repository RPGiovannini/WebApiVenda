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
    public class ProdutoRepository : IProdutoRepository
    {
        private ApplicationDbContext _context;
        public ProdutoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> CreateAsync(Produto produto)
        {
            _context.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> DeleteAsync(Produto produto)
        {
            produto.Ativo = false;
            _context.Update(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            return await _context.Produtos.AsNoTracking().Where(x => x.Ativo).ToListAsync();
        }

        public async Task<Produto?> GetByIdAsync(long? id)
        {
            return await _context.Produtos.AsNoTracking().Where(x => x.Ativo).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Produto> UpdateAsync(Produto produto)
        {
            _context.Update(produto);
            await _context.SaveChangesAsync();
            return produto;
        }
        public async Task<IEnumerable<Produto>> GetByVenda(long idVenda)
        {
            var produtosId = _context.VendaItems.Where(x => x.IdVenda == idVenda).Select(x => x.IdProduto).ToList();
            var produtosVenda = await _context.Produtos.AsNoTracking().Where(x => produtosId.Contains(x.Id)).ToListAsync();
            return produtosVenda;
        }
    }
}
