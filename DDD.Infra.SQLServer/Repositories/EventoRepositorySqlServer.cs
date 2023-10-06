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
    public class EventoRepositorySqlServer : IEventosRepository
    {
        readonly SqlContext _sqlContext;

        public EventoRepositorySqlServer(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public Evento GetEventoById(int id)
        {
            return _sqlContext.Eventos.Find(id);
        }

        public void InsertEvento(Evento evento)
        {
            try
            {
                _sqlContext.Eventos.Add(evento);
                _sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateEvento(Evento evento)
        {
            try
            {
                _sqlContext.Entry(evento).State = EntityState.Modified;
                _sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}