using DDD.Infra.SQLServer.Interfaces;
using DDD.Infra.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Domain.SecretariaContext;

namespace DDD.Infra.SQLServer.Repositories
{
    public class MatriculaRepositorySqlServer : IMatriculaRepository
    {
        private readonly SqlContext _context;
        public MatriculaRepositorySqlServer(SqlContext apiContext)
        {
            _context = apiContext;
        }

        public Matricula GetMatricula(int id)
        {
            return _context.Matriculas.Find(id);
        }
        public void fazerMatricula(Matricula matricula)
        {
            try
            {
                _context.Matriculas.Add(matricula);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
