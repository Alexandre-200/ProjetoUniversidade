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
    public class ParticipanteRepositorySqlServer : IParticipanteRepository
    {
        public readonly SqlContext _sqlContext;

        public ParticipanteRepositorySqlServer(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }
        public void DeleteParticipante(Participante participante)
        {
            try
            {
                _sqlContext.Set<Participante>().Remove(participante);
                _sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Participante GetParticipanteById(int id)
        {
            return _sqlContext.Participantes.Find(id);
        }

        public List<Participante> GetParticipantes()
        {
            return _sqlContext.Participantes.ToList();
        }

        public void InsertParticipante(Participante participante)
        {
            try
            {
                _sqlContext.Participantes.Add(participante);
                _sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateParticipante(Participante participante)
        {
            try
            {
                _sqlContext.Entry(participante).State = EntityState.Modified;
                _sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
