using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training.Domain;
using Training.Repository;

namespace Training.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerguntasController : ControllerBase
    {
        private readonly ITrainingRepository _repo;

        public PerguntasController(ITrainingRepository repo)
        {
            _repo = repo;
        }
        //get all
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllPerguntasAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Houve uma falha na requisição");
            }
        }
        //get by id
        [HttpGet("{PerguntaId}")]
        public async Task<IActionResult> Get(int PerguntaId)
        {
            try
            {
                var results = await _repo.GetPerguntasAsyncById(PerguntaId);
                return Ok(results);

                
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Houve uma falha na requisição");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Pergunta model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/perguntas/{model.Id}", model);
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
        public async Task<IActionResult> Put(int PerguntaId, Pergunta model)
        {
            try
            {
                var pergunta = await _repo.GetPerguntasAsyncById(PerguntaId);
                if (pergunta == null)
                {
                    return NotFound();
                }
                _repo.Update(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/perguntas/{model.Id}", model);
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
        public async Task<IActionResult> Delete(int PerguntaId, Pergunta model)
        {
            try
            {
                var pergunta = await _repo.GetPerguntasAsyncById(PerguntaId);
                if (pergunta == null)
                {
                    return NotFound();
                }
                _repo.Delete(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Ok(pergunta);
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