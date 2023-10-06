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
    public class TipoEventoRepositorySqlServer : ITipoEventosRepository
    {
        readonly SqlContext _sqlContext;

        public TipoEventoRepositorySqlServer(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public TipoEvento GetTipoEventoById(int id)
        {
            return _sqlContext.TipoEventos.Find(id);
        }

        public void InsertTipoEvento(TipoEvento tipoEvento)
        {
            try
            {
                _sqlContext.TipoEventos.Add(tipoEvento);
                _sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateTipoEvento(TipoEvento tipoEvento)
        {
            try
            {
                _sqlContext.Entry(tipoEvento).State = EntityState.Modified;
                _sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}