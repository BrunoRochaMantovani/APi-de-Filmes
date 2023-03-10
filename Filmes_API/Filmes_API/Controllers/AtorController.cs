using Filmes_API.Data;
using Filmes_API.Models;
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

                var ator = new AtorGetViewModel { Id = escolhido.Id, PrimeiroNome = escolhido.PrimeiroNome, UltimoNome = escolhido.UltimoNome, Nacionalidade = escolhido.Nacionalidade, Data_Nascimento = escolhido.Data_Nascimento };
                return Ok(ator);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AtorPostOrPutViewModel model)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest("Modelo informado incorreto");

                var ator = new Ator
                {
                    PrimeiroNome= model.PrimeiroNome,
                    UltimoNome= model.UltimoNome,
                    Nacionalidade= model.Nacionalidade,
                    Data_Nascimento= model.Data_Nascimento
                };

                await _context.Atores.AddAsync(ator);
                await _context.SaveChangesAsync();

                return Ok(ator);

            }catch(Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut(template:"{id}")]
        public async Task<IActionResult> Put([FromBody] AtorPostOrPutViewModel model, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Modelo informado incorreto");

                var ator = await _context
                    .Atores
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (ator is null)
                    return NotFound("Usuário não encontrado");

                ator.PrimeiroNome = model.PrimeiroNome;
                ator.UltimoNome = model.UltimoNome;
                ator.Nacionalidade = model.Nacionalidade;
                ator.Data_Nascimento = model.Data_Nascimento;
               

                _context.Atores.Update(ator);
                await _context.SaveChangesAsync();
                return Ok(ator);

            }
            catch (Exception ex) { return BadRequest(ex.Message);}
        }

        [HttpDelete(template:"{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var ator = await _context
                    .Atores
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (ator is null)
                    return NotFound("Usuário não encontrado");

                _context.Remove(ator);
                await _context.SaveChangesAsync();
                return Ok(ator);
            }
            catch  (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
