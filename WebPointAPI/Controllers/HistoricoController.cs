using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebPointAPI.Models;
using WebPointAPI.Services;

namespace WebPointAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoController : ControllerBase
    {
        private IHistoricoService _historicoService;
            
        public HistoricoController(IHistoricoService historicoService)
        {
            _historicoService = historicoService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Historico>>> GetHistorico()
        {

            try
            {
                var historicos = await _historicoService.GetHistorico();
                return Ok(historicos);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Erro ao obter histórico");
            }

        }

        [HttpGet("{id:int}", Name = "GetHistoricoById")]
        public async Task<ActionResult<Historico>> GetHistoricoById([FromQuery] int Id)
        {
            try
            {
                var usuario = await _historicoService.GetHistoricoById(Id);

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

        public async Task<ActionResult> CreateHistorico(Historico historico)
        {
            try
            {
                await _historicoService.CreateHistorico(historico);

                return CreatedAtRoute(nameof(GetHistoricoById), new { id = historico.ID }, historico);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter o histórico");
            }

        }

        [HttpGet("HistoricoByName")]
        public async Task<ActionResult<IAsyncEnumerable<Historico>>> GetHistoricoByName([FromQuery] string nome)
        {
            try
            {
                var historicos = await _historicoService.GetHistoricoByNome(nome);

                if (historicos.Count() == 0)
                {
                    return NotFound($"Não existe historicos com o nome: {nome}");
                }

                return Ok(historicos);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter historicos");
            }

        }

        [HttpPut ("{id:int}")]

        public async Task<ActionResult> EditHistorico(int id, [FromBody] Historico historico)
        {
            try
            {
                if (historico.ID == id)
                {
                    await _historicoService.UpdateHistorico(historico);
                    return Ok($"Histórico com o id = {id} foi alterado com sucesso.");
                }
                else
                {
                    return BadRequest("histórico não encontrado");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Histórico");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteHistorico(int id)
        {
            try
            {
                var historico = await _historicoService.GetHistoricoById(id);

                if (historico.ID == id)
                {
                    await _historicoService.DeleteHistorico(historico);
                    return Ok($"histórico de id = {id} excluido com sucesso");
                }
                else
                {
                    return NotFound("histórico não encontrado");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Histórico");
            }

        }
    }
}
