using DDD.Domain.EventoContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IInscricaoRepository
    {
        public Inscricao GetInscricaoById(int id);

        public Inscricao InsertInscricao(int idAluno, int idEvento);

        public void UpdateInscricao(Inscricao inscricao);
    }
}
