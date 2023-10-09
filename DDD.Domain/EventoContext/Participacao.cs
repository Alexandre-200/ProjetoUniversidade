using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.EventoContext
{
    public class Participacao
    {
        public int ParticipacaoId { get; set; }
        public int ParticipanteId { get; set; }
        public Participante Participante { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
        public DateTime DataInscricao { get; set; }
    }
}
