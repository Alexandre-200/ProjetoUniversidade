using DDD.Domain.EventoContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipanteController : ControllerBase
    {
        readonly IParticipanteRepository _participanteRepository;

        public ParticipanteController(IParticipanteRepository participanteRepository)
        {
            _participanteRepository = participanteRepository;
        }

        [HttpGet]
        public ActionResult<List<Participante>> Get()
        {
            return Ok(_participanteRepository.GetParticipantes());
        }

        [HttpGet("{id}")]
        public ActionResult<Participante> GetById(int id)
        {
            return Ok(_participanteRepository.GetParticipanteById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Participante> CreateAluno(Participante participante)
        {
            if (participante.Nome.Length < 3 || participante.Nome.Length > 30)
            {
                return BadRequest("Nome deve ser maior que 3 e menor que 30 caracteres.");
            }
            _participanteRepository.InsertParticipante(participante);
            return CreatedAtAction(nameof(GetById), new { id = participante.UserId }, participante);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Participante participante)
        {
            try
            {
                if (participante == null)
                {
                    return NotFound();
                }
                _participanteRepository.UpdateParticipante(participante);
                return Ok("Participante Atualizado");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete()]
        public ActionResult Delete([FromBody] Participante participante)
        {
            try
            {
                if (participante == null)
                    return NotFound();
                _participanteRepository.DeleteParticipante(participante);
                return Ok("Participante Removido.");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}