using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.EventoContext
{
    public class TutorEvento
    {
        public int TutorEventoId { get; set; }
        public int TutorId { get; set; }
        public Tutor Tutor { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
        public DateTime DataInscricao { get; set; }
    }
}
