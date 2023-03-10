using Filmes_API.Data;
using Filmes_API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Filmes_API.Controllers
{
    [ApiController]
    [Route("/v1/ator")]
    public class AtorController : Controller
    {
        private readonly AppDbContext _context;

        public AtorController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                var todos = await _context
                        .Atores
                        .AsNoTracking()
                        .ToListAsync();

                List<AtorGetViewModel> atorGetViewModels = new List<AtorGetViewModel>();

                foreach (var obj in todos)
                {
                    var ator = new AtorGetViewModel { Id = obj.Id, PrimeiroNome = obj.PrimeiroNome, UltimoNome = obj.UltimoNome, Nacionalidade = obj.Nacionalidade, Data_Nascimento = obj.Data_Nascimento };
                    atorGetViewModels.Add(ator);
                }

                return Ok(atorGetViewModels);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet(template: "{id}")]
        public async Task<IActionResult> ListarUm(int id)
        {
            try
            {
                var escolhido = await _context
                        .Atores
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == id);
                if (escolhido == null)
                    return BadRequest("Usuario não encontrado");
                var ator = new AtorGetViewModel { Id = obj.Id, PrimeiroNome = obj.PrimeiroNome, UltimoNome = obj.UltimoNome, Nacionalidade = obj.Nacionalidade, Data_Nascimento = obj.Data_Nascimento };
                return Ok(ator);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
