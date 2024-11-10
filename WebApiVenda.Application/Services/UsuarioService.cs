using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiVenda.Application.DTOs;
using WebApiVenda.Application.Interfaces;
using WebApiVenda.Domain.Entities;
using WebApiVenda.Domain.Interfaces;

namespace WebApiVenda.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task Add(UsuarioDTO usuarioDTO)
        {
            await _usuarioRepository.CreateAsync(_mapper.Map<Usuario>(usuarioDTO));
        }

        public async Task Delete(UsuarioDTO usuarioDTO)
        {
            await _usuarioRepository.DeleteAsync(_mapper.Map<Usuario>(usuarioDTO));
        }

        public async Task<IEnumerable<UsuarioDTO>> GetAll()
        {
            var usuarioEntity = await _usuarioRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarioEntity);
        }

        public async Task<UsuarioDTO> GetId(long? id)
        {
            var usuarioEntity = await _usuarioRepository.GetIdAsyc(id);
            return _mapper.Map<UsuarioDTO>(usuarioEntity);
        }

        public async Task Update(UsuarioDTO usuarioDTO)
        {
            await _usuarioRepository.UpdateAsync(_mapper.Map<Usuario>(usuarioDTO));
        }

    }
}
