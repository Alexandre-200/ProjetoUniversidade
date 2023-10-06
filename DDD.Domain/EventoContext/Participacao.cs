using DDD.Domain.SecretariaContext;
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

        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public int EventoId { get; set; }
        public Evento Evento { get; set; }
        public DateTime DataInscricao { get; set; }

    }
}
