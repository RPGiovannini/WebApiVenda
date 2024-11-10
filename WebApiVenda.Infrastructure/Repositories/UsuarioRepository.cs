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
    public class UsuarioRepository : IUsuarioRepository
    {
        private ApplicationDbContext _context;
        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> DeleteAsync(Usuario usuario)
        {
            var existingUsuario = _context.Usuarios.FirstOrDefault(u => u.Id == usuario.Id);
            if (existingUsuario != null)
            {
                usuario.Ativo = false;
                _context.Update(usuario);
                await _context.SaveChangesAsync();
                return usuario;
            }
            return null;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.AsNoTracking().Where(x => x.Ativo).ToListAsync();
        }

        public async Task<Usuario> GetIdAsyc(long? id)
        {
            return await _context.Usuarios.AsNoTracking().Where(x => x.Ativo).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Usuario> UpdateAsync(Usuario usuario)
        {
            _context.Update(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
        public async Task<Usuario> GetEmailAsyc(string email)
        {
            var usuario = await _context.Usuarios.AsNoTracking().Where(x => x.Ativo).FirstOrDefaultAsync(x => x.Email == email);
            return usuario;
        }
    }
}
