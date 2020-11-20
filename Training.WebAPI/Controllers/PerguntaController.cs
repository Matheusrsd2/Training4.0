using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Domain;
using Training.Repository;

namespace Training.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerguntaController : Controller
    {
        public readonly ITrainingRepository _repo;

        public PerguntaController(ITrainingRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetPerguntasAsync();
                return Ok(result);
            }
            catch (SystemException)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Houve uma falha na requisição");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post (Pergunta model)
        {
            _repo.Add(model);
            if (await _repo.SaveChangesAsync())
            {
                return Created($"/api/pergunta/{model.Id}", model);
            }
            return BadRequest();
        }
    }
}
