using Contratacao.Application.DTOs;
using Contratacao.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Contratacao.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContratosController : ControllerBase
    {
        private readonly ContratarPropostaHandler _contratarHandler;
        private readonly ListarContratosHandler _listarHandler;

        public ContratosController(
            ContratarPropostaHandler contratarHandler,
            ListarContratosHandler listarHandler)
        {
            _contratarHandler = contratarHandler;
            _listarHandler = listarHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Contratar([FromBody] Contratacao.Application.DTOs.ContratarPropostaRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var contrato = await _contratarHandler.HandleAsync(request);
                return CreatedAtAction(nameof(ObterPorId), new { id = contrato.Id }, contrato);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var contratos = await _listarHandler.HandleAsync();
            return Ok(contratos);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var contratos = await _listarHandler.HandleAsync();
            var contrato = contratos.FirstOrDefault(c => c.Id == id);
            return contrato is not null ? Ok(contrato) : NotFound();
        }
    }
}
