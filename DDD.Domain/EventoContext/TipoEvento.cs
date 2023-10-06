using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.EventoContext
{
    public class TipoEvento
    {
        public int TipoEventoId { get; set; }
        public string Nome { get; set; }
        public List<Evento>? Eventos { get; set; }
    }
}
