using DDD.Domain;
using DDD.Infra.SQLServer.Interfaces;
using DDD.Infra.SQLServer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        readonly IDisciplinaRepository _disciplinaRepository;
        public DisciplinaController(IDisciplinaRepository disciplinaRepository) {
            _disciplinaRepository = disciplinaRepository;
        }

        [HttpGet]
        public ActionResult<List<Disciplina>> Get()
        {
            return Ok(_disciplinaRepository.GetDisciplinas());
        }

        [HttpGet("{id}")]
        public ActionResult<Disciplina> GetbyId(int id)
        {
            return Ok(_disciplinaRepository.GetDisciplina(id));
        }

        [HttpPost]
        public ActionResult<Disciplina> CreateDisciplina(Disciplina disciplina)
        {
            _disciplinaRepository.InsertDisciplina(disciplina);
            return CreatedAtAction(nameof(GetbyId), new { id = disciplina.DisciplinaId }, disciplina);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Disciplina disciplina)
        {
            try
            {
                if (disciplina == null)
                {
                    return BadRequest();
                }
                _disciplinaRepository.UpdateDisciplina(disciplina);
                return Ok("Disciplina Atualizada com Sucesso");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] Disciplina disciplina)
        {
            try
            {
                if (disciplina == null)
                {
                    return BadRequest();
                }
                _disciplinaRepository.DeleteDisciplina(disciplina);
                return Ok("Disciplina Deletada com Sucesso");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
