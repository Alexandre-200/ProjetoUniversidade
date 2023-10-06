using DDD.Domain.EventoContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface ITutorEventoRepository
    {
        public TutorEvento GetTutorEventoById(int id);

        public TutorEvento InsertTutorEvento(int idTutor, int idEvento);

        public void UpdateTutorEvento(TutorEvento tutorEvento);
    }
}
