using Filmes_API.Data;
using Filmes_API.Models;
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
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
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
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GeneroPostOrPutViewModel model)
        {
            //return Ok("OK");
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("O Modelo informado está incorreto ");

                var genero = new Genero { NomeGenero = model.NomeGenero };


                await _context.Generos.AddAsync(genero);
                await _context.SaveChangesAsync();
                return Ok(genero);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }


        [HttpPut(template:"{id}")]
        public async Task<IActionResult> Put([FromBody] GeneroPostOrPutViewModel model,
                int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Modelo invalido");

                var genero = await _context
                        .Generos
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == id);
                if (genero is null)
                    return BadRequest("Genero não encontrado");

                genero.NomeGenero = model.NomeGenero;

                _context.Generos.Update(genero);
                await _context.SaveChangesAsync();

                return RedirectToAction("ListarTodos");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete(template:"{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var genero = await _context.Generos
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == id);

                if (genero is null)
                    return BadRequest("Usuário não encontrado");

                _context.Generos.Remove(genero);

                await _context.SaveChangesAsync();

                return RedirectToAction("ListarTodos");

            }
            catch(Exception ex) { return BadRequest(ex.Message); }
        }
    
    }
}
