using DDD.Domain.SecretariaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.EventoContext
{
    public class Evento
    {
        public int EventoId { get; set; }
        public DateTime Data { get; set; }

        public string Detalhe { get; set; }

        public int TipoEventosId { get; set; }
        public TipoEvento? TipoEventos { get; set; }
        public IList<Aluno>? Alunos { get; set; }
        public IList<Tutor>? Tutors { get; set; }
    }
}
