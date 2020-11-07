using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training.Domain;
using Training.Repository;

namespace Training.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AulaController : ControllerBase
    {
        private readonly ITrainingRepository _repo;

        public AulaController(ITrainingRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get () 
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

        [HttpGet("{AulaId}")]
        public async Task<IActionResult> GetById (int AulaId)
        {
            try
            {
                var results = await _repo.GetAulaAsyncById(AulaId);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, "Essa Aula não foi encontrada");
            }
        }
    }
}