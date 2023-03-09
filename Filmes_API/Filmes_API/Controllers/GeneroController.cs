using Filmes_API.Data;
using Filmes_API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Filmes_API.Controllers
{
    [ApiController]
    [Route("/v1/genero")]
    public class GeneroController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GeneroController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                var todos = await _context
                        .Generos
                        .AsNoTracking()
                        .ToListAsync();
               List<GeneroGetViewModel> generoGetViewModels= new List<GeneroGetViewModel>();

               foreach(var obj in todos)
                {
                   var genero = new GeneroGetViewModel { Id= obj.Id, NomeGenero = obj.NomeGenero };
                   generoGetViewModels.Add(genero);
                }

                return Ok(generoGetViewModels);
            }catch(Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet(template:"{id}")]
        public async Task<IActionResult> ListarUm(int id)
        {
            try
            {
                var escolhido = await _context
                        .Generos
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == id);
                if (escolhido == null)
                    return BadRequest("Usuario não encontrado");
                var escolhidoGetViewModel = new GeneroGetViewModel { Id = escolhido.Id, NomeGenero = escolhido.NomeGenero };
                return Ok(escolhidoGetViewModel);
            }
            catch(Exception ex) { return BadRequest(ex.Message); }
        }

        //[HttpPost]
        //public async Task<IActionResult> Post()

    }
}
