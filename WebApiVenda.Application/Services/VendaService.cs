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
        private IProdutoRepository _produtoRepository;
        private IVendaItemRepository _vendaItemRepository;
        public VendaService(IMapper mapper, IVendaRepository vendaRepository, IProdutoRepository produtoRepository, IVendaItemRepository vendaItemRepository)
        {
            _vendaRepository = vendaRepository ?? throw new ArgumentNullException(nameof(vendaRepository));
            _mapper = mapper;
            _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
            _vendaItemRepository = vendaItemRepository ?? throw new ArgumentNullException(nameof(vendaItemRepository));
        }


        public async Task Add(VendaDTO vendaDTO)
        {
            var venda = new Venda(vendaDTO.Id,vendaDTO.IdCliente, vendaDTO.DataVenda, vendaDTO.ValorVenda,vendaDTO.Status);
            await _vendaRepository.CreateAsync(venda);
        }

        public async Task Cancel(VendaDTO vendaDTO)
        {
            if (vendaDTO.Status == (int)EVendaStatus.Cancelada || vendaDTO.Status == (int)EVendaStatus.Aberta)
            {
                throw new InvalidOperationException("Não é possível cancelar uma venda que já está cancelada ou aberta.");
            }
            var produtos = await _produtoRepository.GetByVenda(vendaDTO.Id);
            var items = await _vendaItemRepository.GetByVendaAsync(vendaDTO.Id);
            foreach (var produto in produtos)
            {
                produto.Estoque += items.Where(x => x.IdProduto == produto.Id).Sum(x => x.Quantidade);
                await _produtoRepository.UpdateAsync(produto);
            }
            var venda = new Venda(vendaDTO.Id, vendaDTO.IdCliente, vendaDTO.DataVenda, vendaDTO.ValorVenda, vendaDTO.Status);
            await _vendaRepository.CancelAsync(venda);
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
            var venda = new Venda(vendaDTO.Id, vendaDTO.IdCliente, vendaDTO.DataVenda, vendaDTO.ValorVenda, vendaDTO.Status);
            await _vendaRepository.UpdateAsync(venda);
        }
        public async Task FinalizeSale(VendaDTO vendaDTO)
        {
            vendaDTO.Status = (int)EVendaStatus.Fechada;
            var venda = new Venda(vendaDTO.Id, vendaDTO.IdCliente, vendaDTO.DataVenda, vendaDTO.ValorVenda, vendaDTO.Status);
            await _vendaRepository.UpdateAsync(venda);
            var produtos = await _produtoRepository.GetByVenda(vendaDTO.Id);
            var items = await _vendaItemRepository.GetByVendaAsync(vendaDTO.Id);
            foreach (var produto in produtos)
            {
                produto.Estoque -= items.Where(x=>x.IdProduto == produto.Id).Sum(x=>x.Quantidade);
                await _produtoRepository.UpdateAsync(produto);
            }
        }
    }
}
