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

        public async Task<Produto> Delete(Produto produto)
        {
            produto.Ativo = false;
            _context.Update(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            return await _context.Produtos.AsNoTracking().ToListAsync();
        }

        public async Task<Produto?> GetByIdAsync(long? id)
        {
            return await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Produto> UpdateAsync(Produto produto)
        {
            _context.Update(produto);
            await _context.SaveChangesAsync();
            return produto;
        }
    }
}
