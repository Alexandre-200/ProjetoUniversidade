
using DDD.Domain.EventoContext;
using DDD.Domain.UserManagementContext;

namespace DDD.Domain.SecretariaContext
{
    public class Aluno : User
    {
        /*
        Em Domain come�amos a modelar as entidades, a classe Aluno herda, 
        todos os seus atributos de User, posteriormente ser� crianda uma 
        tabela no DB. V� para Interfaces/IAlunoRepository na pasta 4 - Infra 
        */

        public List<Disciplina>? Disciplinas { get; set; }

        public List<Evento>? Eventos { get; set; }

    }
}
