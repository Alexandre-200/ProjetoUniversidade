using DDD.Domain;
using DDD.Infra.MemoryDb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.MemoryDb.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly ApiContext _context;
        public MatriculaRepository(ApiContext apiContext)
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
