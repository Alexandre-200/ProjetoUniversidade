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
    public class ParticipacaoRepositorySqlServer : IParticipacaoRepository
    {

        readonly SqlContext _sqlContext;

        public ParticipacaoRepositorySqlServer(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public Participacao GetParticipacaoById(int id)
        {
            return _sqlContext.Participacoes.Find(id);
        }

        public Participacao InsertParticipacao(int idParticipante, int idEvento)
        {
            var participante = _sqlContext.Participantes.First(a => a.UserId == idParticipante);
            var evento = _sqlContext.Eventos.First(e => e.EventoId == idEvento);

            var participacao = new Participacao
            {
                Participante = participante,
                Evento = evento
            };

            try
            {
                _sqlContext.Add(participacao);
                _sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException;
                throw;
            }

            return participacao;
        }



        public void UpdateParticipacao(Participacao participacao)
        {
            try
            {
                _sqlContext.Entry(participacao).State = EntityState.Modified;
                _sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}