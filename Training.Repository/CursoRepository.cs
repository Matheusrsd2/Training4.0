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
                .Include(c => c.Aulas);

            query = query.OrderByDescending(c => c.DataCadastro);

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
    }
}