using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        readonly IAlunoRepository _alunoRepository;

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        // GET: api/<AlunosController>
        [HttpGet]
        public ActionResult<List<Aluno>> Get()
        {
            return Ok(_alunoRepository.GetAlunos());
        }

        [HttpGet("{id}")]
        public ActionResult<Aluno> GetbyId(int id) {
            return Ok(_alunoRepository.GetAluno(id));
        }

        [HttpPost]
        public ActionResult<Aluno> CreateAluno(Aluno aluno)
        {
            _alunoRepository.InsertAluno(aluno);
            return CreatedAtAction(nameof(GetbyId), new { id = aluno.UserId }, aluno);
        }

        [HttpPut]
        public ActionResult Put([FromBody]Aluno aluno)
        {
            try
            {
                if(aluno == null)
                {
                    return BadRequest();
                }
                _alunoRepository.UpdateAluno(aluno);
                return Ok("Aluno Atualizado com Sucesso");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] Aluno aluno)
        {
            try
            {
                if (aluno == null)
                {
                    return BadRequest();
                }
                _alunoRepository.DeleteAluno(aluno);
                return Ok("Aluno Deletado com Sucesso");
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
