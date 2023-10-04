using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using WebPointAPI.Models;
using WebPointAPI.Services;

namespace WebPointAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioService _usuarioService;
        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Usuario>>> GetUsuarios(int id)
        {
            try
            {
                var usuarios = await _usuarioService.GetUsuarios();

                if (usuarios.Count() == 0)
                {
                    return NotFound($"Não existe usuarios com o id {id}");
                }

                return Ok(usuarios);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Usuario");
            }
        }
        [HttpGet ("UsuarioByName")]
        public async Task<ActionResult<IAsyncEnumerable<Usuario>>> GetUsuarioByName([FromQuery]string nome)
        {
            try
            {
                var usuarios = await _usuarioService.GetUsuariosByNome(nome);

                if (usuarios.Count() == 0)
                {
                    return NotFound($"Não existe usuarios com o critério {nome}" );
                }

                return Ok(usuarios);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Usuarios");
            }

        }

        [HttpGet("{id:int}", Name = "GetUsuarioById")]
        public async Task<ActionResult<Usuario>> GetUsuarioById([FromQuery] int Id)
        {
            try
            {
                var usuario = await _usuarioService.GetUsuario(Id);

                if (usuario == null)
                {
                    return NotFound($"Não existe usuarios com o id {Id}");
                }

                return Ok(usuario);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Usuarios");
            }

        }

        [HttpPost]

        public async Task<ActionResult> CreateUsuario(Usuario usuario)
        {
            try
            {
                await _usuarioService.CreatUsuario(usuario);

                return CreatedAtRoute(nameof(GetUsuarioById), new {id = usuario.UsuarioId}, usuario);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Usuarios");
            }

        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult> Edit(int id, [FromBody] Usuario usuario)
        {
            try
            {
                if(usuario.UsuarioId == id)
                {
                    await _usuarioService.UpdateUsuario(usuario);  
                    return Ok($"Usuário com o id = {id} foi alterado com sucesso.");
                }
                else
                {
                    return BadRequest("usuario não encontrado");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Usuarios");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var usuario = await _usuarioService.GetUsuario(id);

                if (usuario.UsuarioId == id)
                {
                    await _usuarioService.DeleteUsuario(usuario);
                    return Ok($"usuario de id = {id} excluido com sucesso");
                }
                else
                {
                    return NotFound("usuario não encontrado");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Usuarios");
            }

        }
    }

}
