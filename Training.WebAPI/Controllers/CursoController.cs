using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training.Domain;
using Training.Repository;

namespace Training.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ITrainingRepository _repo;

        public CursoController(ITrainingRepository repo)
        {
            _repo = repo;
        }
        //get all
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllCursosAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Houve uma falha na requisição");
            }
        }
        //get by id
        [HttpGet("{CursoId}")]
        public async Task<IActionResult> Get(int CursoId)
        {
            try
            {
                var results = await _repo.GetCursoAsyncById(CursoId);
                return Ok(results);

                
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Houve uma falha na requisição");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Curso model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/curso/{model.Id}", model);
                }
                //return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Houve uma falha na requisição");
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int CursoId, Curso model)
        {
            try
            {
                var curso = await _repo.GetCursoAsyncById(CursoId);
                if (curso == null)
                {
                    return NotFound();
                }
                _repo.Update(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/curso/{model.Id}", model);
                }
                //return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Houve uma falha na requisição");
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int CursoId, Curso model)
        {
            try
            {
                var curso = await _repo.GetCursoAsyncById(CursoId);
                if (curso == null)
                {
                    return NotFound();
                }
                _repo.Delete(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Ok(curso);
                }
                //return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Houve uma falha na requisição");
            }
            return BadRequest();
        }
        
        
    }
}