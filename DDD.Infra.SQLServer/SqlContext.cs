using DDD.Domain.EventoContext;
using DDD.Domain.PicContext;
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
            // modelBuilder.Entity<Matricula>().HasKey(m => new { m.AlunoId, m.DisciplinaId });
            //HasKey() serve para indicar a chave primária, seja ela simples ou composta. 
            modelBuilder.Entity<Aluno>()
                    .HasMany(d => d.Disciplinas)
                    .WithMany(a => a.Alunos)
                    .UsingEntity<Matricula>();

            modelBuilder.Entity<User>().UseTpcMappingStrategy();
            modelBuilder.Entity<Aluno>().ToTable("Aluno");
            modelBuilder.Entity<Pesquisador>().ToTable("Pesquisador");
            //modelBuilder.Entity<Tutor>().ToTable("Tutors");

            modelBuilder.Entity<Aluno>()
                .HasMany(e => e.Eventos)
                .WithMany(a => a.Alunos)
                .UsingEntity<Participacao>();

            modelBuilder.Entity<Tutor>()
                .HasMany(e => e.Eventos)
                .WithMany(a => a.Tutors)
                .UsingEntity<TutorEvento>();

            modelBuilder.Entity<TipoEvento>()
                .HasMany(e => e.Eventos)
                .WithOne(e => e.TipoEventos)
                .HasForeignKey(e => e.TipoEventosId)
                .HasPrincipalKey(e => e.TipoEventoId);

        }

        //DbSet -> representa a coleção de todas as entidades no contexto ou que
        //podem ser consultadas do banco de dados de um determinado tipo.
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Pesquisador> Pesquisadores { get; set; }
        public DbSet<Projeto> Projetos { get; set; }


        public DbSet<TipoEvento> TipoEventos { get; set; }

        public DbSet<Evento> Eventos { get; set; }

        public DbSet<Participacao> Participacaos { get; set; }

        public DbSet<Tutor> Tutors { get; set; }

        public DbSet<TutorEvento> TutorEventos { get; set; }


    }
}