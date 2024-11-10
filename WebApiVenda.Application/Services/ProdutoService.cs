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
    public class ProdutoService : IProdutoService
    {
        private IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        public ProdutoService(IMapper mapper, IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
            _mapper = mapper;
        }



        public async Task Add(ProdutoDTO produtoDTO)
        {
            Produto produto = new Produto(produtoDTO.Id, produtoDTO.Descricao, produtoDTO.Preco, produtoDTO.Estoque, produtoDTO.DataCadastro);
            await _produtoRepository.CreateAsync(produto);
        }

        public async Task Delete(ProdutoDTO produtoDTO)
        {
            Produto produto = new Produto(produtoDTO.Id, produtoDTO.Descricao, produtoDTO.Preco, produtoDTO.Estoque, produtoDTO.DataCadastro);
            await _produtoRepository.DeleteAsync(produto);
        }

        public async Task<IEnumerable<ProdutoDTO>> GetAll()
        {
            var produtoEntity = await _produtoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtoEntity);
        }

        public async Task<ProdutoDTO> GetId(long? id)
        {
            var produtoEntity = await _produtoRepository.GetByIdAsync(id);
            return _mapper.Map<ProdutoDTO>(produtoEntity);
        }

        public async Task Update(ProdutoDTO produtoDTO)
        {
            Produto produto = new Produto(produtoDTO.Id, produtoDTO.Descricao, produtoDTO.Preco, produtoDTO.Estoque, produtoDTO.DataCadastro);
            await _produtoRepository.UpdateAsync(produto);
        }
        public async Task<IEnumerable<ProdutoDTO>> GetByVenda(long idVenda)
        {
            var produtoEntity = await _produtoRepository.GetByVenda(idVenda);
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtoEntity);
        }
    }
}
