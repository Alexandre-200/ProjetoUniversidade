﻿// <auto-generated />
using System;
using DDD.Infra.SQLServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DDD.Infra.SQLServer.Migrations
{
    [DbContext(typeof(SqlContext))]
    partial class SqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("UserSequence");

            modelBuilder.Entity("DDD.Domain.EventoContext.Evento", b =>
                {
                    b.Property<int>("EventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventoId"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Detalhe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoEventosId")
                        .HasColumnType("int");

                    b.HasKey("EventoId");

                    b.HasIndex("TipoEventosId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("DDD.Domain.EventoContext.Participacao", b =>
                {
                    b.Property<int>("ParticipacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ParticipacaoId"));

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataInscricao")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.HasKey("ParticipacaoId");

                    b.HasIndex("AlunoId");

                    b.HasIndex("EventoId");

                    b.ToTable("Participacaos");
                });

            modelBuilder.Entity("DDD.Domain.EventoContext.TipoEvento", b =>
                {
                    b.Property<int>("TipoEventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoEventoId"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoEventoId");

                    b.ToTable("TipoEventos");
                });

            modelBuilder.Entity("DDD.Domain.EventoContext.TutorEvento", b =>
                {
                    b.Property<int>("TutorEventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TutorEventoId"));

                    b.Property<DateTime>("DataInscricao")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<int>("TutorId")
                        .HasColumnType("int");

                    b.HasKey("TutorEventoId");

                    b.HasIndex("EventoId");

                    b.HasIndex("TutorId");

                    b.ToTable("TutorEventos");
                });

            modelBuilder.Entity("DDD.Domain.PicContext.Projeto", b =>
                {
                    b.Property<int>("ProjetoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjetoId"));

                    b.Property<int>("AnosDuracao")
                        .HasColumnType("int");

                    b.Property<string>("DescricaoProjeto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeProjeto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PesquisadorUserId")
                        .HasColumnType("int");

                    b.HasKey("ProjetoId");

                    b.HasIndex("PesquisadorUserId");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("DDD.Domain.SecretariaContext.Disciplina", b =>
                {
                    b.Property<int>("DisciplinaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DisciplinaId"));

                    b.Property<bool>("Disponivel")
                        .HasColumnType("bit");

                    b.Property<bool>("Ead")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DisciplinaId");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("DDD.Domain.SecretariaContext.Matricula", b =>
                {
                    b.Property<int>("MatriculaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MatriculaId"));

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("int");

                    b.HasKey("MatriculaId");

                    b.HasIndex("AlunoId");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("Matriculas");
                });

            modelBuilder.Entity("DDD.Domain.UserManagementContext.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR [UserSequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<int>("UserId"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("DDD.Domain.EventoContext.Tutor", b =>
                {
                    b.HasBaseType("DDD.Domain.UserManagementContext.User");

                    b.ToTable("Tutors");
                });

            modelBuilder.Entity("DDD.Domain.PicContext.Pesquisador", b =>
                {
                    b.HasBaseType("DDD.Domain.UserManagementContext.User");

                    b.Property<string>("Titulacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Pesquisador", (string)null);
                });

            modelBuilder.Entity("DDD.Domain.SecretariaContext.Aluno", b =>
                {
                    b.HasBaseType("DDD.Domain.UserManagementContext.User");

                    b.ToTable("Aluno", (string)null);
                });

            modelBuilder.Entity("DDD.Domain.EventoContext.Evento", b =>
                {
                    b.HasOne("DDD.Domain.EventoContext.TipoEvento", "TipoEventos")
                        .WithMany("Eventos")
                        .HasForeignKey("TipoEventosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoEventos");
                });

            modelBuilder.Entity("DDD.Domain.EventoContext.Participacao", b =>
                {
                    b.HasOne("DDD.Domain.SecretariaContext.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DDD.Domain.EventoContext.Evento", "Evento")
                        .WithMany()
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Evento");
                });

            modelBuilder.Entity("DDD.Domain.EventoContext.TutorEvento", b =>
                {
                    b.HasOne("DDD.Domain.EventoContext.Evento", "Evento")
                        .WithMany()
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DDD.Domain.EventoContext.Tutor", "Tutor")
                        .WithMany()
                        .HasForeignKey("TutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("DDD.Domain.PicContext.Projeto", b =>
                {
                    b.HasOne("DDD.Domain.PicContext.Pesquisador", null)
                        .WithMany("projetos")
                        .HasForeignKey("PesquisadorUserId");
                });

            modelBuilder.Entity("DDD.Domain.SecretariaContext.Matricula", b =>
                {
                    b.HasOne("DDD.Domain.SecretariaContext.Aluno", "aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DDD.Domain.SecretariaContext.Disciplina", "disciplina")
                        .WithMany()
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("aluno");

                    b.Navigation("disciplina");
                });

            modelBuilder.Entity("DDD.Domain.EventoContext.TipoEvento", b =>
                {
                    b.Navigation("Eventos");
                });

            modelBuilder.Entity("DDD.Domain.PicContext.Pesquisador", b =>
                {
                    b.Navigation("projetos");
                });
#pragma warning restore 612, 618
        }
    }
}
