using Filmes_API.Data;
using Filmes_API.Models;
using Filmes_API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Filmes_API.Controllers
{
    [ApiController]
    [Route("/v1/nacionalidade")]
    public class NacionalidadeController : Controller
    {
        private readonly AppDbContext _context;

        public NacionalidadeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                var todos = await _context
                        .Nacionalidades
                        .AsNoTracking()
                        .ToListAsync();

                return Ok(todos);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet(template: "{id}")]
        public async Task<IActionResult> ListarUm(int id)
        {
            try
            {
                var escolhido = await _context
                        .Nacionalidades
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == id);
                if (escolhido == null)
                    return BadRequest("Nacionalidade não encontrada");
               
                return Ok(escolhido);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NacionalidadePostOrPutViewModel model)
        {
            //return Ok("OK");
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("O Modelo informado está incorreto ");

                var nacionalidade = new Nacionalidade { Pais = model.Pais };


                await _context.Nacionalidades.AddAsync(nacionalidade);
                await _context.SaveChangesAsync();
                return Ok(nacionalidade);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut(template: "{id}")]
        public async Task<IActionResult> Put([FromBody] NacionalidadePostOrPutViewModel model,
                int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Modelo invalido");

                var nacionalidade = await _context
                        .Nacionalidades
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == id);
                if (nacionalidade is null)
                    return BadRequest("Genero não encontrado");

                nacionalidade.Pais = model.Pais;

                _context.Nacionalidades.Update(nacionalidade);
                await _context.SaveChangesAsync();

                return Ok(nacionalidade);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete(template: "{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var nacionalidade = await _context.Nacionalidades
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == id);

                if (nacionalidade is null)
                    return BadRequest("Usuário não encontrado");

                _context.Nacionalidades.Remove(nacionalidade);

                await _context.SaveChangesAsync();

                return Ok(nacionalidade);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
