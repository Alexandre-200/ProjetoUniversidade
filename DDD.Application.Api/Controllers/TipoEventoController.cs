using DDD.Domain.EventoContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEventoController : ControllerBase
    {
        readonly ITipoEventosRepository _tipoEventosRepository;

        public TipoEventoController(ITipoEventosRepository tipoEventosRepository)
        {
            _tipoEventosRepository = tipoEventosRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<TipoEvento> GetById(int id)
        {
            return Ok(_tipoEventosRepository.GetTipoEventoById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TipoEvento> CreateTipoEvento(TipoEvento tipoEvento)
        {
            if (tipoEvento.Nome.Length < 3 || tipoEvento.Nome.Length > 30)
            {
                return BadRequest("Nome deve ser maior que 3 e menor que 30 caracteres.");
            }
            _tipoEventosRepository.InsertTipoEvento(tipoEvento);
            return CreatedAtAction(nameof(GetById), new { id = tipoEvento.TipoEventoId }, tipoEvento);
        }

        [HttpPut]
        public ActionResult Put([FromBody] TipoEvento tipoEvento)
        {
            try
            {
                if (tipoEvento == null)
                {
                    return NotFound();
                }
                _tipoEventosRepository.UpdateTipoEvento(tipoEvento);
                return Ok("Tipo de Evento Atualizado.");
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}