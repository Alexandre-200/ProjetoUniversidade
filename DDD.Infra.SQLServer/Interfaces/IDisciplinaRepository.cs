﻿using DDD.Domain.SecretariaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IDisciplinaRepository
    {
        public List<Disciplina> GetDisciplinas();

        public Disciplina GetDisciplina(int id);

        public void DeleteDisciplina(Disciplina disciplina);

        public void UpdateDisciplina(Disciplina disciplina);

        public void InsertDisciplina(Disciplina disciplina);
    }
}
