using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
using DDD.Infra.SQLServer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        readonly IMatriculaRepository _matriculaRepository;

        /*
        
        mesmo a interface IMatriculaRepository não tendo uma implementação
        ela fornece uma instancia de MatriculaRepository, veja Program.cs 
        pois essa é a classe que fornece a instancia de MatriculaRepository
        
        */

        public MatriculaController(IMatriculaRepository matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<Matricula> GetbyId(int id)
        {
            //return Ok(_matriculaRepository.GetMatricula(id));
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult<Matricula> CreateMatricula(Matricula matricula)
        {
            //_matriculaRepository.fazerMatricula(matricula);
            //return CreatedAtAction(nameof(GetbyId), new { id = matricula.Id }, matricula);
            throw new NotImplementedException();
        }


    }
}
