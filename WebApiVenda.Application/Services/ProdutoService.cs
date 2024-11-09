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

        public Produto ReturnMappingDTOToEntity(ProdutoDTO produtoDTO)
        {
            return _mapper.Map<Produto>(produtoDTO);
        }
        public async Task Add(ProdutoDTO produtoDTO)
        {
            await _produtoRepository.CreateAsync(ReturnMappingDTOToEntity(produtoDTO));
        }

        public async Task Delete(ProdutoDTO produtoDTO)
        {
            await _produtoRepository.Delete(ReturnMappingDTOToEntity(produtoDTO));
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
            await _produtoRepository.UpdateAsync(ReturnMappingDTOToEntity(produtoDTO));
        }
    }
}
