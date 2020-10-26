using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training.Domain;
using Training.Repository;

namespace Training.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ITrainingRepository _repo;

        public CategoriasController(ITrainingRepository repo)
        {
            _repo = repo;
        }
        //get all
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllCategoriasAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Houve uma falha na requisição");
            }
        }
        //get by id
        [HttpGet("{CategoriaId}")]
        public async Task<IActionResult> Get(int CategoriaId)
        {
            try
            {
                var results = await _repo.GetCategoriaAsyncById(CategoriaId);
                return Ok(results);

                
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Houve uma falha na requisição");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Categoria model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/categorias/{model.Id}", model);
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
        public async Task<IActionResult> Put(int CategoriaId, Categoria model)
        {
            try
            {
                var categoria = await _repo.GetCategoriaAsyncById(CategoriaId);
                if (categoria == null)
                {
                    return NotFound();
                }
                _repo.Update(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/categorias/{model.Id}", model);
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
        public async Task<IActionResult> Delete(int CategoriaId, Categoria model)
        {
            try
            {
                var categoria = await _repo.GetCategoriaAsyncById(CategoriaId);
                if (categoria == null)
                {
                    return NotFound();
                }
                _repo.Delete(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Ok(categoria);
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