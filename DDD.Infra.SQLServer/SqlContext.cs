using DDD.Domain.SecretariaContext;
using DDD.Domain.UserManagementContext;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.SQLServer
{
    public class SqlContext: DbContext
    {
        //Esse método deve ser sobreescrito para configurar o banco de dados,
        //sendo chamado para cada contexto em que é utilizado
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //UseSqlServer -> Configura o contexto para se conectar a um
            //banco de dados do Microsoft SQL Server
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UniversidadeDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Matricula>().HasKey(m => new { m.AlunoId, m.DisciplinaId });
            //HasKey() serve para indicar a chave primária, seja ela simples ou composta. 
        }

        //DbSet -> representa a coleção de todas as entidades no contexto ou que
        //podem ser consultadas do banco de dados de um determinado tipo.
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<User> Users { get; set; }  

    }
}