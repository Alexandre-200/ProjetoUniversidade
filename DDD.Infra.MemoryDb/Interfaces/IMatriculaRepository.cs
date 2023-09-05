using DDD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.MemoryDb.Interfaces
{
    public interface IMatriculaRepository
    {
        public Matricula GetMatricula(int id);
        public void fazerMatricula(Matricula matricula);
    }
}
