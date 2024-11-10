using Microsoft.AspNetCore.Mvc;
using WebApiVenda.Application.DTOs;
using WebApiVenda.Application.Interfaces;

namespace WebApiVenda.Api.Controllers
{
    [Route("api/v1/[Controller]")]
    public class ProdutosController : ApiControllerBase
    {
        private readonly IProdutoService _produtoService;
        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get()
        {
            var produtos = await _produtoService.GetAll();
            return Ok(produtos);
        }
        [HttpGet("{id}", Name = "GetProduto")]
        public async Task<ActionResult<ProdutoDTO>> Get(long id)
        {
            var produto = await _produtoService.GetId(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProdutoDTO produtoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _produtoService.Add(produtoDTO);

            return new CreatedAtRouteResult("GetProduto", new { id = produtoDTO.Id }, produtoDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoDTO>> Delete(int id) 
        {
            var produtoDto = await _produtoService.GetId(id);
            if (produtoDto == null) 
            {
                return NotFound();
            }
            await _produtoService.Delete(produtoDto);
            return Ok(produtoDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] ProdutoDTO produtoDTO) 
        {
            if(id != produtoDTO.Id) 
            {
                return BadRequest();
            }
            await _produtoService.Update(produtoDTO);
            return Ok(produtoDTO);
        }
    }
}
