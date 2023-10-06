using DDD.Domain.EventoContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface ITutorRepository
    {
        public List<Tutor> GetTutors();
        public Tutor GetTutorById(int id);

        public void InsertTutor(Tutor tutor);

        public void UpdateTutor(Tutor tutor);

        public void DeleteTutor(Tutor tutor);
    }
}
