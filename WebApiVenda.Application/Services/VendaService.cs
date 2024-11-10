using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiVenda.Application.DTOs;
using WebApiVenda.Application.Interfaces;
using WebApiVenda.Domain.Entities;
using WebApiVenda.Domain.Enums;
using WebApiVenda.Domain.Interfaces;

namespace WebApiVenda.Application.Services
{
    public class VendaService : IVendaService
    {
        private IVendaRepository _vendaRepository;
        private readonly IMapper _mapper;

        public VendaService(IMapper mapper, IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository ?? throw new ArgumentNullException(nameof(vendaRepository));
            _mapper = mapper;
        }
        public Venda ReturnMappingDTOToEntity(VendaDTO vendaDTO)
        {
            return _mapper.Map<Venda>(vendaDTO);
        }
        public async Task Add(VendaDTO vendaDTO)
        {
            await _vendaRepository.CreateAsync(ReturnMappingDTOToEntity(vendaDTO));
        }

        public async Task Cancel(VendaDTO vendaDTO)
        {
            await _vendaRepository.CancelAsync(ReturnMappingDTOToEntity(vendaDTO));
        }

        public async Task<IEnumerable<VendaDTO>> GetAll()
        {
            var vendaEntity = await _vendaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<VendaDTO>>(vendaEntity);
        }

        public async Task<VendaDTO> GetId(long? id)
        {
           var vendaEntity = await _vendaRepository.GetIdAsync(id);
            return _mapper.Map<VendaDTO>(vendaEntity);
        }

        public async Task Update(VendaDTO vendaDTO)
        {
          await _vendaRepository.UpdateAsync(ReturnMappingDTOToEntity(vendaDTO));
        }
        public async Task FinalizeSale(VendaDTO vendaDTO)
        {
            vendaDTO.Status = (int)EVendaStatus.Fechada;
            await _vendaRepository.UpdateAsync(ReturnMappingDTOToEntity(vendaDTO));
        }
    }
}
