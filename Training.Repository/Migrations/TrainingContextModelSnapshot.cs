﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Training.Repository;

namespace Training.Repository.Migrations
{
    [DbContext(typeof(TrainingContext))]
    partial class TrainingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Training.Domain.Aula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CursoId");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Descricao");

                    b.Property<DateTime>("Duracao");

                    b.Property<string>("VideoAula");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.ToTable("Aulas");
                });

            modelBuilder.Entity("Training.Domain.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Training.Domain.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaId");

                    b.Property<decimal>("Classificacao");

                    b.Property<DateTime?>("DataCadastro");

                    b.Property<string>("Imagem");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("Training.Domain.Pergunta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AulaId");

                    b.Property<string>("Imagem1");

                    b.Property<string>("Imagem2");

                    b.Property<string>("Imagem3");

                    b.Property<string>("TextoResposta");

                    b.Property<int?>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("AulaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Perguntas");
                });

            modelBuilder.Entity("Training.Domain.Resposta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Imagem1");

                    b.Property<string>("Imagem2");

                    b.Property<string>("Imagem3");

                    b.Property<int?>("PerguntaId");

                    b.Property<string>("TextoResposta");

                    b.Property<int?>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("PerguntaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Respostas");
                });

            modelBuilder.Entity("Training.Domain.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodigoCartao");

                    b.Property<string>("Cpf");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.Property<string>("NumeroCartao");

                    b.Property<string>("Profissao");

                    b.Property<string>("Senha");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Training.Domain.UsuarioCurso", b =>
                {
                    b.Property<int>("UsuarioId");

                    b.Property<int>("CursoId");

                    b.HasKey("UsuarioId", "CursoId");

                    b.HasIndex("CursoId");

                    b.ToTable("UsuriosCursos");
                });

            modelBuilder.Entity("Training.Domain.Aula", b =>
                {
                    b.HasOne("Training.Domain.Curso", "Curso")
                        .WithMany("Aulas")
                        .HasForeignKey("CursoId");
                });

            modelBuilder.Entity("Training.Domain.Curso", b =>
                {
                    b.HasOne("Training.Domain.Categoria", "categoria")
                        .WithMany("Cursos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Training.Domain.Pergunta", b =>
                {
                    b.HasOne("Training.Domain.Aula", "Aula")
                        .WithMany("Perguntas")
                        .HasForeignKey("AulaId");

                    b.HasOne("Training.Domain.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("Training.Domain.Resposta", b =>
                {
                    b.HasOne("Training.Domain.Pergunta", "Pergunta")
                        .WithMany("Respostas")
                        .HasForeignKey("PerguntaId");

                    b.HasOne("Training.Domain.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("Training.Domain.UsuarioCurso", b =>
                {
                    b.HasOne("Training.Domain.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Training.Domain.Usuario", "Usuario")
                        .WithMany("UsuariosCursos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
