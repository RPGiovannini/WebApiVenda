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
    public class ClienteService : IClienteService
    {
        private IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

    

        public async Task Add(ClienteDTO clienteDTO)
        {
            var cliente = new Cliente(clienteDTO.Id, clienteDTO.Nome, clienteDTO.DataCadastro);
            await _clienteRepository.CreateAsync(cliente);
        }

        public async Task Delete(ClienteDTO clienteDTO)
        {
            var cliente = new Cliente(clienteDTO.Id, clienteDTO.Nome, clienteDTO.DataCadastro);
            await _clienteRepository.DeleteAsync(cliente);
        }

        public async Task<IEnumerable<ClienteDTO>> GetAll()
        {
            var clienteEntity = await _clienteRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClienteDTO>>(clienteEntity);
        }

        public async Task<ClienteDTO> GetId(long? id)
        {
            var clienteEntity = await _clienteRepository.GetIdAsyc(id);
            return _mapper.Map<ClienteDTO>(clienteEntity);
        }

        public async Task Update(ClienteDTO clienteDTO)
        {
            var cliente = new Cliente(clienteDTO.Id, clienteDTO.Nome, clienteDTO.DataCadastro);
            await _clienteRepository.UpdateAsync(cliente);
        }
    }
}
