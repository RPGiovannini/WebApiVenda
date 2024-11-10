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
        private IVendaRepository _vendaRepository;
        private IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public VendaItemService(IMapper mapper, IVendaItemRepository vendaItemRepository, IVendaRepository vendaRepository, IProdutoRepository produtoRepository)
        {
            _vendaItemRepository = vendaItemRepository ?? throw new ArgumentNullException(nameof(vendaItemRepository));
            _mapper = mapper;
            _vendaRepository = vendaRepository;
            _produtoRepository = produtoRepository;
        }
        public async Task Add(VendaItemDTO vendaItemDTO)
        {

            var produto = await _produtoRepository.GetByIdAsync(vendaItemDTO.IdProduto);
            vendaItemDTO.PrecoUnitario = produto != null ? produto.Preco : 0;
            VendaItem vendaItem = new VendaItem(vendaItemDTO.Id, vendaItemDTO.IdVenda, vendaItemDTO.IdProduto, vendaItemDTO.Quantidade, vendaItemDTO.IdFinalizadora, vendaItemDTO.PrecoUnitario);
            await _vendaItemRepository.CreateAsync(vendaItem);
            await UpdateVenda(vendaItemDTO, false);
        }

        public async Task Cancel(VendaItemDTO vendaItemDTO)
        {
            VendaItem vendaItem = new VendaItem(vendaItemDTO.Id, vendaItemDTO.IdVenda, vendaItemDTO.IdProduto, vendaItemDTO.Quantidade, vendaItemDTO.IdFinalizadora, vendaItemDTO.PrecoUnitario);

            await _vendaItemRepository.CancelAsync(vendaItem);
            await UpdateVenda(vendaItemDTO, true);
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
            VendaItem vendaItem = new VendaItem(vendaItemDTO.Id, vendaItemDTO.IdVenda, vendaItemDTO.IdProduto, vendaItemDTO.Quantidade, vendaItemDTO.IdFinalizadora, vendaItemDTO.PrecoUnitario);

            await _vendaItemRepository.UpdateAsync(vendaItem);
        }

        private async Task UpdateVenda(VendaItemDTO vendaItemDTO, bool cancelamentoItem)
        {
            var venda = await _vendaRepository.GetIdAsync(vendaItemDTO.IdVenda);
            if (!cancelamentoItem)
            {
                venda.ValorVenda += vendaItemDTO.Quantidade * vendaItemDTO.PrecoUnitario;
            }
            else 
            {
                venda.ValorVenda -= vendaItemDTO.Quantidade * vendaItemDTO.PrecoUnitario;
            }
            await _vendaRepository.UpdateAsync(venda);
        }
    }
}
