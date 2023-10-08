using DDD.Domain.EventoContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscricaoController : Controller
    {
        readonly IInscricaoRepository _inscricaoRepository;

        public InscricaoController(IInscricaoRepository inscricaoRepository)
        {
            _inscricaoRepository = _inscricaoRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<Inscricao> GetById(int id)
        {
            return Ok(_inscricaoRepository.GetInscricaoById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Inscricao> CreateParticipacao(int idAluno, int idEvento)
        {
            Inscricao participacaoIdSaved = _inscricaoRepository.InsertInscricao(idAluno, idEvento);
            return CreatedAtAction(nameof(GetById), new { id = participacaoIdSaved.InscricaoId }, participacaoIdSaved);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Inscricao inscricao)
        {
            try
            {
                if (inscricao == null)
                    return NotFound();

                _inscricaoRepository.UpdateInscricao(inscricao);
                return Ok("Participação Atualizada.");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}