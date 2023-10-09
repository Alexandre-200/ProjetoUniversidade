using DDD.Domain.EventoContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IParticipanteRepository
    {
        public List<Participante> GetParticipantes();
        public Participante GetParticipanteById(int id);

        public void InsertParticipante(Participante participante);

        public void UpdateParticipante(Participante participante);

        public void DeleteParticipante(Participante participante);
    }
}
