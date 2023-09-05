using DDD.Domain;
using DDD.Infra.MemoryDb.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.MemoryDb.Repositories
{
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private readonly ApiContext _context;
        public DisciplinaRepository(ApiContext apiContext)
        {
            _context = apiContext;
        }

        public void DeleteDisciplina(Disciplina disciplina)
        {
            try
            {
                _context.Set<Disciplina>().Remove(disciplina);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Disciplina GetDisciplina(int id)
        {
            return _context.Disciplinas.Find(id);
        }

        public List<Disciplina> GetDisciplinas()
        {
            var list = _context.Disciplinas.ToList();
            return list;
        }

        public void InsertDisciplina(Disciplina disciplina)
        {
            try
            {
                _context.Disciplinas.Add(disciplina);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateDisciplina(Disciplina disciplina)
        {
            try
            {
                _context.Entry(disciplina).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
