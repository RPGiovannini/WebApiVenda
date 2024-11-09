using Microsoft.AspNetCore.Mvc;
using WebApiVenda.Application.DTOs;
using WebApiVenda.Application.Interfaces;

namespace WebApiVenda.Api.Controllers
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class ClientesController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get()
        {
            var clientes = await _clienteService.GetAll();
            return Ok(clientes);
        }
        [HttpGet("{id}", Name = "GetCliente")]
        public async Task<ActionResult<ClienteDTO>> Get(long id)
        {
            var cliente = await _clienteService.GetId(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteDTO clienteDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _clienteService.Add(clienteDTO);
            return new CreatedAtRouteResult("GetCliente", new { id = clienteDTO.Id }, clienteDTO);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteDTO>> Delete(int id)
        {
            var clienteDto = await _clienteService.GetId(id);
            if (clienteDto == null)
            {
                return NotFound();
            }
            await _clienteService.Delete(clienteDto);
            return Ok(clienteDto);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] ClienteDTO clienteDTO)
        {
            if (id != clienteDTO.Id)
            {
                return BadRequest();
            }
            await _clienteService.Update(clienteDTO);
            return Ok(clienteDTO);
        }

    }
}
