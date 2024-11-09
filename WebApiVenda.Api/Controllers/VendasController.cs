

using Microsoft.AspNetCore.Mvc;
using WebApiVenda.Application.DTOs;
using WebApiVenda.Application.Interfaces;

namespace WebApiVenda.Api.Controllers
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class VendasController : Controller
    {
        private readonly IVendaService _vendaService;
        public VendasController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendaDTO>>> Get()
        {
            var vendas = await _vendaService.GetAll();
            return Ok(vendas);
        }
        [HttpGet("{id}", Name = "GetVenda")]
        public async Task<ActionResult<VendaDTO>> Get(long id)
        {
            var venda = await _vendaService.GetId(id);
            if (venda == null)
            {
                return NotFound();
            }
            return Ok(venda);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VendaDTO vendaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _vendaService.Add(vendaDTO);

            return new CreatedAtRouteResult("GetVenda", new { id = vendaDTO.Id }, vendaDTO);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<VendaDTO>> Cancel(int id)
        {
            var vendaDto = await _vendaService.GetId(id);
            if (vendaDto == null)
            {
                return NotFound();
            }
            await _vendaService.Cancel(vendaDto);
            return Ok(vendaDto);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] VendaDTO vendaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _vendaService.Update(vendaDTO);
            return Ok(vendaDTO);
        }
    }
}
