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
    public class VendaItemService : IVendaItemService
    {
        private IVendaItemRepository _vendaItemRepository;
        private readonly IMapper _mapper;

        public VendaItemService(IMapper mapper, IVendaItemRepository vendaItemRepository)
        {
            _vendaItemRepository = vendaItemRepository ?? throw new ArgumentNullException(nameof(vendaItemRepository));
            _mapper = mapper;
        }
        public async Task Add(VendaItemDTO vendaItemDTO)
        {
            await _vendaItemRepository.CreateAsync(_mapper.Map<VendaItem>(vendaItemDTO));
        }

        public async Task Cancel(VendaItemDTO vendaItemDTO)
        {
            await _vendaItemRepository.CancelAsync(_mapper.Map<VendaItem>(vendaItemDTO));
        }

        public async Task<IEnumerable<VendaItemDTO>> GetAll()
        {
            var vendaItemEntity = await _vendaItemRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<VendaItemDTO>>(vendaItemEntity);
        }

        public async Task<VendaItemDTO> GetId(long? id)
        {
            var vendaItemEntity = await _vendaItemRepository.GetIdAsync(id);
            return _mapper.Map<VendaItemDTO>(vendaItemEntity);
        }

        public async Task Update(VendaItemDTO vendaItemDTO)
        {
          await _vendaItemRepository.UpdateAsync(_mapper.Map<VendaItem>(vendaItemDTO));
        }
    }
}
