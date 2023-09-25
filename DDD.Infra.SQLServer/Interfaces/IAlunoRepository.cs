using DDD.Domain.SecretariaContext;

namespace DDD.Infra.SQLServer.Interfaces
{
    /*
    contrato com todos os metodos que devem ser implementados
    pelas classes que implementarem essa interface
    */
    public interface IAlunoRepository
    {
        public List<Aluno> GetAlunos();

        public Aluno GetAluno(int id);

        public void DeleteAluno(Aluno aluno);

        public void UpdateAluno(Aluno aluno);

        public void InsertAluno(Aluno aluno);

    }
}
