using DDD.Domain.SecretariaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IMatriculaRepository
    {
        public Matricula GetMatricula(int id);
        public void fazerMatricula(Matricula matricula);
    }
}
