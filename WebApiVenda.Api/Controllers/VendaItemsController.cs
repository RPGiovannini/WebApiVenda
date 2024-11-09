using Microsoft.AspNetCore.Mvc;
using WebApiVenda.Application.DTOs;
using WebApiVenda.Application.Interfaces;

namespace WebApiVenda.Api.Controllers
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class VendaItemsController : Controller
    {
        private readonly IVendaItemService _vendaItemService;
        public VendaItemsController(IVendaItemService vendaItemService)
        {
            _vendaItemService = vendaItemService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendaItemDTO>>> Get()
        {
            var vendaItems = await _vendaItemService.GetAll();
            return Ok(vendaItems);
        }
        [HttpGet("{id}", Name = "GetVendaItem")]
        public async Task<ActionResult<VendaItemDTO>> Get(long id)
        {
            var vendaItem = await _vendaItemService.GetId(id);
            if (vendaItem == null)
            {
                return NotFound();
            }
            return Ok(vendaItem);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VendaItemDTO vendaItemDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _vendaItemService.Add(vendaItemDTO);

            return new CreatedAtRouteResult("GetVendaItem", new { id = vendaItemDTO.Id }, vendaItemDTO);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<VendaItemDTO>> Cancel(int id)
        {
            var vendaItemDto = await _vendaItemService.GetId(id);
            if (vendaItemDto == null)
            {
                return NotFound();
            }
            await _vendaItemService.Cancel(vendaItemDto);
            return Ok(vendaItemDto);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] VendaItemDTO vendaItemDTO)
        {
            if (id != vendaItemDTO.Id)
            {
                return BadRequest();
            }
            await _vendaItemService.Update(vendaItemDTO);
            return Ok(vendaItemDTO);
        }
    }
}
