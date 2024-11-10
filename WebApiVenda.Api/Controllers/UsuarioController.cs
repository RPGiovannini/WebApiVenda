using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NpgsqlTypes;
using WebApiVenda.Application.DTOs;
using WebApiVenda.Application.Interfaces;
using WebApiVenda.Domain.Entities;

namespace WebApiVenda.Api.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class UsuarioController : ApiControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetUsuarios()
        {
            var usuarios = await _usuarioService.GetAll();
            return Ok(usuarios);
        }

        [HttpGet("{id}", Name = "GetUsuario")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuario(int id)
        {
            var usuario = await _usuarioService.GetId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioDTO usuario)
        {
            await _usuarioService.Add(usuario);
            return new CreatedAtRouteResult("GetUsuario", new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UsuarioDTO usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            await _usuarioService.Update(usuario);
            return Ok(usuario);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioDTO>> DeleteUsuario(int id)
        {
            var usuarioDto = await _usuarioService.GetId(id);
            if (usuarioDto == null)
            {
                return NotFound();
            }
            await _usuarioService.Delete(usuarioDto);
            return Ok(usuarioDto);
        }
    }
}
