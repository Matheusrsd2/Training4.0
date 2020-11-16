using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Training.Domain;

namespace Training.Repository
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly TrainingContext _context ;

        public TrainingRepository(TrainingContext context)
        {
            _context = context;

        }
        //Adicionar
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Curso[]> GetAllCursosAsync()
        {
            IQueryable<Curso> query = _context.Cursos
                .Include(c => c.Aulas)
                .OrderBy(c => c.Id);


            return await query.ToArrayAsync();
        }

        public async Task<Curso[]> GetCursoAsyncById(int CursoId)
        {
            IQueryable<Curso> query = _context.Cursos
                .Include(c => c.Aulas);
            if(query != null)
            query = query.Where(c => c.Id == CursoId);
            return await query.ToArrayAsync();
        }

        public async Task<Aula[]> GetAllAulasAsync () 
        {
            IQueryable<Aula> query = _context.Aulas
            .Include(x => x.Perguntas);
            if (query != null)
            query = query.OrderBy(x => x.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Aula[]> GetAulaAsyncById(int AulaId) 
        {
            IQueryable<Aula> query = _context.Aulas
                .Include(c => c.Perguntas);
            if(query != null)
            query = query.Where(c => c.Id == AulaId);
            return await query.ToArrayAsync();
        }

    }
}
