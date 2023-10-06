using DDD.Domain.EventoContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IEventosRepository
    {
        public Evento GetEventoById(int id);
        public void InsertEvento(Evento evento);
        public void UpdateEvento(Evento evento);
    }
}
