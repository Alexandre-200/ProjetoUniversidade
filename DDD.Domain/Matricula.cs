using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    public class Matricula
    {

        public int Id{ get; set; }
        public int DisciplinaId { get; set; }

        public int AlunoId { get; set; }
    }
}
