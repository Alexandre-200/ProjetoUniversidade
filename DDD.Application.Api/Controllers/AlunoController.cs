using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    /*
    classe que cria os end points
    GET: Método genérico para qualquer requisição que busca dados do servidor;
    POST: Método genérico para qualquer requisição que envia dados ao servidor;
    PUT: Método específico para atualização de dados no servidor
    DELETE: Método específico para remoção de dados no servidor. 
    */
    [Route("api/[controller]")]
    [ApiController] 
    public class AlunoController : ControllerBase
    {
        
        readonly IAlunoRepository _alunoRepository;

        /*
        Em program.cs deixamos claro que quando utlizamos IAlunoRepository 
        (onde temos apenas as assinaturas dos metodos) na verdade estamos 
        instanciando AlunoRepositorySqlServer
        (classe que implementa a interface, logo implementou seus metodos)         
        */

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

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
                return Ok("Aluno Atualizado.");
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
                return Ok("Aluno Deletado.");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
