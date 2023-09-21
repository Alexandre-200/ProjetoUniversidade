﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.SecretariaContext
{
    public class Matricula
    {

        public int MatriculaId { get; set; }


        public int DisciplinaId { get; set; }

        public Disciplina disciplina { get; set; }  


        public int AlunoId { get; set; }

        public Aluno aluno { get; set; } 

        public DateTime Data { get; set; }
    }
}
