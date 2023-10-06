using DDD.Domain.EventoContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorEventoController : Controller
    {
        readonly ITutorEventoRepository _tutorEventoRepository;

        public TutorEventoController(ITutorEventoRepository tutorEventoRepository)
        {
            _tutorEventoRepository = tutorEventoRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<TutorEvento> GetById(int id)
        {
            return Ok(_tutorEventoRepository.GetTutorEventoById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TutorEvento> CreateParticipacao(int idTutor, int idEvento)
        {
            TutorEvento tutorEventoIdSaved = _tutorEventoRepository.InsertTutorEvento(idTutor, idEvento);
            return CreatedAtAction(nameof(GetById), new { id = tutorEventoIdSaved.TutorEventoId }, tutorEventoIdSaved);
        }

        [HttpPut]
        public ActionResult Put([FromBody] TutorEvento tutorEvento)
        {
            try
            {
                if (tutorEvento == null)
                    return NotFound();

                _tutorEventoRepository.UpdateTutorEvento(tutorEvento);
                return Ok("Tutor Atualizado.");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
