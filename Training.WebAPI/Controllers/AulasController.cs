using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training.Domain;
using Training.Repository;

namespace Training.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AulasController : ControllerBase
    {
        private readonly ITrainingRepository _repo;

        public AulasController(ITrainingRepository repo)
        {
            _repo = repo;
        }
        //get all
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllAulasAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Houve uma falha na requisição");
            }
        }
        //get by id
        [HttpGet("{AulaId}")]
        public async Task<IActionResult> Get(int AulaId)
        {
            try
            {
                var results = await _repo.GetAulasAsyncById(AulaId);
                return Ok(results);

                
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Houve uma falha na requisição");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Aula model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/aulas/{model.Id}", model);
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
        public async Task<IActionResult> Put(int AulaId, Aula model)
        {
            try
            {
                var aula = await _repo.GetAulasAsyncById(AulaId);
                if (aula == null)
                {
                    return NotFound();
                }
                _repo.Update(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/aulas/{model.Id}", model);
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
        public async Task<IActionResult> Delete(int AulaId, Aula model)
        {
            try
            {
                var aula = await _repo.GetAulasAsyncById(AulaId);
                if (aula == null)
                {
                    return NotFound();
                }
                _repo.Delete(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Ok(aula);
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