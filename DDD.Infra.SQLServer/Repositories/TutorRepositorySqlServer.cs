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
    public class TutorRepositorySqlServer : ITutorRepository
    {
        public readonly SqlContext _sqlContext;

        public TutorRepositorySqlServer(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }
        public void DeleteTutor(Tutor tutor)
        {
            try
            {
                _sqlContext.Set<Tutor>().Remove(tutor);
                _sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Tutor GetTutorById(int id)
        {
            return _sqlContext.Tutors.Find(id);
        }

        public List<Tutor> GetTutors()
        {
            return _sqlContext.Tutors.ToList();
        }

        public void InsertTutor(Tutor tutor)
        {
            try
            {
                _sqlContext.Tutors.Add(tutor);
                _sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateTutor(Tutor tutor)
        {
            try
            {
                _sqlContext.Entry(tutor).State = EntityState.Modified;
                _sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
