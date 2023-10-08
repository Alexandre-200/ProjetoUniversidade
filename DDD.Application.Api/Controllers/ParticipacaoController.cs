using DDD.Domain.EventoContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipacaoController : Controller
    {
        readonly IParticipacaoRepository _participacaoRepository;

        public ParticipacaoController(IParticipacaoRepository participacaoRepository)
        {
            _participacaoRepository = participacaoRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<Participacao> GetById(int id)
        {
            return Ok(_participacaoRepository.GetParticipacaoById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Participacao> CreateParticipacao(int idTutor, int idEvento)
        {
            Participacao participacaoIdSaved = _participacaoRepository.InsertParticipacao(idTutor, idEvento);
            return CreatedAtAction(nameof(GetById), new { id = participacaoIdSaved.ParticipacaoId }, participacaoIdSaved);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Participacao tutorEvento)
        {
            try
            {
                if (tutorEvento == null)
                    return NotFound();

                _participacaoRepository.UpdateParticipacao(tutorEvento);
                return Ok("Tutor Atualizado.");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
