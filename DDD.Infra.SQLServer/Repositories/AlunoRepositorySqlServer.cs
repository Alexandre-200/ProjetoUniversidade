using DDD.Infra.SQLServer.Interfaces;
using DDD.Infra.SQLServer;
using Microsoft.EntityFrameworkCore;
using DDD.Domain.SecretariaContext;

namespace DDD.Infra.SQLServer.Repositories
{
    public class AlunoRepositorySqlServer : IAlunoRepository
    {
        private readonly SqlContext _sqlContext;

        /*
        Inje��o de depend�ncia: t�cnica para livrar ou remover o acoplamento 
        entre os objetos e seus colaboradores, esses colaboradores s�o fornecidos
        para a classe dependente de um modo particular, v� em 2 - Application/Program.cs
        */

        public AlunoRepositorySqlServer(SqlContext sqlContext)
        {
            //construtor que faz parte da inje��o de dependencia 
            _sqlContext = sqlContext;
        }

        public void DeleteAluno(Aluno aluno)
        {
            try
            {
                _sqlContext.Set<Aluno>().Remove(aluno);
                //Retorna uma DbSet<TEntity> inst�ncia para acesso a
                //entidades do tipo especificado no contexto e no
                //reposit�rio subjacente.

                _sqlContext.SaveChanges();
                // SaveChanges() -> O Entity FrameWork detecta todas
                // as altera��es sendo elas mantidas no BD 
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Aluno GetAluno(int id)
        {
            return _sqlContext.Alunos.Find(id);
            // Find -> usa a chave prim�ria para construir a
            // consulta SQL e a envia ao banco de dados para
            // recuperar os dados. 
        }

        public List<Aluno> GetAlunos()
        {
            var list = _sqlContext.Alunos.ToList();
            //ToList() -> retorna uma lista de determinada consulta, no caso de Aluno

            return list;
        }

        public void InsertAluno(Aluno aluno)
        {
            try
            {
                _sqlContext.Alunos.Add(aluno);
                _sqlContext.SaveChanges();
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
                _sqlContext.Entry(aluno).State = EntityState.Modified;
                // EntityState.Modified -> anexa uma entidade existente
                // por�m que foi modificada ao contexto, todas as propriedades
                // da entidade ser�o marcadas como modificadas e todos os valores
                // de propriedade ser�o enviados para o banco de dados quando
                // SaveChanges for chamado

                _sqlContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
