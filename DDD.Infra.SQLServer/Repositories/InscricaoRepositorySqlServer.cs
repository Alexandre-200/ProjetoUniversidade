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
    public class InscricaoRepositorySqlServer : IInscricaoRepository
    {

        readonly SqlContext _sqlContext;

        public InscricaoRepositorySqlServer(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public Inscricao GetInscricaoById(int id)
        {
            return _sqlContext.Inscricoes.Find(id);
        }

        public Inscricao InsertInscricao(int idAluno, int idEvento)
        {
            var aluno = _sqlContext.Alunos.First(a => a.UserId == idAluno);
            var evento = _sqlContext.Eventos.First(e => e.EventoId == idEvento);

            var participacao = new Inscricao
            {
                Aluno = aluno,
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



        public void UpdateInscricao(Inscricao inscricao)
        {
            try
            {
                _sqlContext.Entry(inscricao).State = EntityState.Modified;
                _sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}