using DDD.Domain.EventoContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IParticipacaoRepository
    {
        public Participacao GetParticipacaoById(int id);

        public Participacao InsertParticipacao(int idTutor, int idEvento);

        public void UpdateParticipacao(Participacao tutorEvento);
    }
}
