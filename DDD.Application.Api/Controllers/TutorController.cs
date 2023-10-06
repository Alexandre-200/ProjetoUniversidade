using DDD.Domain.EventoContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        readonly ITutorRepository _tutorRepository;

        public TutorController(ITutorRepository tutorRepository)
        {
            _tutorRepository = tutorRepository;
        }

        [HttpGet]
        public ActionResult<List<Tutor>> Get()
        {
            return Ok(_tutorRepository.GetTutors());
        }

        [HttpGet("{id}")]
        public ActionResult<Tutor> GetById(int id)
        {
            return Ok(_tutorRepository.GetTutorById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Tutor> CreateAluno(Tutor tutor)
        {
            if (tutor.Nome.Length < 3 || tutor.Nome.Length > 30)
            {
                return BadRequest("Nome deve ser maior que 3 e menor que 30 caracteres.");
            }
            _tutorRepository.InsertTutor(tutor);
            return CreatedAtAction(nameof(GetById), new { id = tutor.UserId }, tutor);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Tutor tutor)
        {
            try
            {
                if (tutor == null)
                {
                    return NotFound();
                }
                _tutorRepository.UpdateTutor(tutor);
                return Ok("Tutor Atualizado");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete()]
        public ActionResult Delete([FromBody] Tutor tutor)
        {
            try
            {
                if (tutor == null)
                    return NotFound();
                _tutorRepository.DeleteTutor(tutor);
                return Ok("Tutor Removido.");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}