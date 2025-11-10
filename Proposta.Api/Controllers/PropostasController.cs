using Microsoft.AspNetCore.Mvc;
using Proposta.Api.DTOs;
using Proposta.Application.DTOs;
using Proposta.Application.Interfaces;
using Proposta.Application.Services;

namespace Proposta.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropostaController : ControllerBase
    {
        private readonly IPropostaService _propostaService;

        public PropostaController(IPropostaService propostaService)
        {
            _propostaService = propostaService;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarPropostaRequest request)
        {
            var proposta = await _propostaService.CreateAsync(new CreatePropostaDto { ClienteNome = request.NomeSegurado, Valor = request.Valor}, default);
            return CreatedAtAction(nameof(ObterPorId), new { id = proposta }, proposta);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var proposta = await _propostaService.GetByIdAsync(id);
            if (proposta == null)
                return NotFound();

            return Ok(proposta);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var propostas = await _propostaService.ListAsync();
            return Ok(propostas);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> AtualizarStatus(Guid id, [FromBody] AtualizarStatusRequest request)
        {
            await _propostaService.UpdateStatusAsync(id, request.NovoStatus, default);

            return NoContent();
        }
    }
}
