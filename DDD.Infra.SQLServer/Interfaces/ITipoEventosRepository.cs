using DDD.Domain.EventoContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface ITipoEventosRepository
    {
        public TipoEvento GetTipoEventoById(int id);
        public void InsertTipoEvento(TipoEvento tipoEvento);

        public void UpdateTipoEvento(TipoEvento tipoEvento);
    }
}
