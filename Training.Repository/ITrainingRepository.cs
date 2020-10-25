using System.Threading.Tasks;
using Training.Domain;

namespace Training.Repository
{
    public interface ITrainingRepository
    {
         void Add<T> (T entity) where T : class;
         void Update<T> (T entity) where T : class;
         void Delete<T> (T entity) where T : class;
         Task <bool> SaveChangesAsync();

        //Cursos 
         Task<Curso[]> GetAllCursosAsync ();
         Task<Curso[]> GetCursoAsyncById(int CursoId);
    }
}