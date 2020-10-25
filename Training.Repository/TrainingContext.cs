using Microsoft.EntityFrameworkCore;
using Training.Domain;

namespace Training.Repository
{
    public class TrainingContext : DbContext
    {
        public TrainingContext(DbContextOptions<TrainingContext> options) : base (options) {}
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Pergunta> Perguntas { get; set; }
        public DbSet<Resposta> Respostas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioCurso> UsuriosCursos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioCurso>()
            .HasKey(PE => new { PE.UsuarioId, PE.CursoId});
        }
    }
}