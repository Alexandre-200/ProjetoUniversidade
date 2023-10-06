using DDD.Domain.EventoContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        readonly IEventosRepository _eventosRepository;

        public EventoController(IEventosRepository eventosRepository)
        {
            _eventosRepository = eventosRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<Evento> GetById(int id)
        {
            return Ok(_eventosRepository.GetEventoById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Evento> CreateTipoEvento(Evento evento)
        {

            _eventosRepository.InsertEvento(evento);
            return CreatedAtAction(nameof(GetById), new { id = evento.EventoId }, evento);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Evento evento)
        {
            try
            {
                if (evento == null)
                {
                    return NotFound();
                }
                _eventosRepository.UpdateEvento(evento);
                return Ok("Evento Atualizado.");
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}