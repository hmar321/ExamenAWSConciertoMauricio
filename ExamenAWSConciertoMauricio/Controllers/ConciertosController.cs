using ExamenAWSConciertoMauricio.Models;
using ExamenAWSConciertoMauricio.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamenAWSConciertoMauricio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConciertosController : ControllerBase
    {
        private RepositoryConciertos repo;

        public ConciertosController(RepositoryConciertos repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Evento>>> Eventos()
        {
            return await this.repo.GetEventosAsync();
        }

        [HttpGet]
        [Route("[action]/{idcategoria}")]
        public async Task<ActionResult<List<Evento>>> EventosByIdCategoria(int idcategoria)
        {
            return await this.repo.FindEventosByCategoriaAsync(idcategoria);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<CategoriaEvento>>> CategoriasEvento()
        {
            return await this.repo.GetCategoriasEventoAsync();
        }
    }
}
