using DDD.Infra.SQLServer.Interfaces;
using DDD.Infra.SQLServer;
using Microsoft.EntityFrameworkCore;
using DDD.Domain.SecretariaContext;

namespace DDD.Infra.SQLServer.Repositories
{
    public class AlunoRepositorySqlServer : IAlunoRepository
    {
        private readonly SqlContext _context;
        //o que é injecao de dependencia
        public AlunoRepositorySqlServer(SqlContext apiContext)
        {
            _context = apiContext;
        }

        public void DeleteAluno(Aluno aluno)
        {
            try
            {
                _context.Set<Aluno>().Remove(aluno);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public Aluno GetAluno(int id)
        {
            return _context.Alunos.Find(id);
        }

        public List<Aluno> GetAlunos()
        {
            var list = _context.Alunos.ToList();
            return list;
        }

        public void InsertAluno(Aluno aluno)
        {
            try
            {
                _context.Alunos.Add(aluno);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateAluno(Aluno aluno)
        {
            try
            {
                _context.Entry(aluno).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
