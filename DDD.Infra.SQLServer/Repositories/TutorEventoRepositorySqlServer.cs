using DDD.Domain.EventoContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories
{
    public class TutorEventoRepositorySqlServer : ITutorEventoRepository
    {

        readonly SqlContext _sqlContext;

        public TutorEventoRepositorySqlServer(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public TutorEvento GetTutorEventoById(int id)
        {
            return _sqlContext.TutorEventos.Find(id);
        }

        public TutorEvento InsertTutorEvento(int idEventoTutor, int idEvento)
        {
            var tutor = _sqlContext.Tutors.First(a => a.UserId == idEventoTutor);
            var evento = _sqlContext.Eventos.First(e => e.EventoId == idEvento);

            var tutorEvento = new TutorEvento
            {
                Tutor = tutor,
                Evento = evento
            };

            try
            {
                _sqlContext.Add(tutorEvento);
                _sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException;
                throw;
            }

            return tutorEvento;
        }



        public void UpdateTutorEvento(TutorEvento tutorEvento)
        {
            try
            {
                _sqlContext.Entry(tutorEvento).State = EntityState.Modified;
                _sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}