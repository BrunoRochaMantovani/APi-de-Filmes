using Filmes_API.Data;
using Filmes_API.Extensions;
using Filmes_API.Models;
using Filmes_API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Runtime;

namespace Filmes_API.Controllers
{
    [ApiController]
    [Route("/v1/filme")]
    [Authorize(Roles = "administrador")]
    public class FilmeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FilmeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ListarTodos()
        {
            try 
            {
                var filmes = await _context.Filmes
                .AsNoTracking()
                .Include(x => x.Genero)
                .Include(x => x.Diretor)
                .ToListAsync();
                List<FilmeGetViewModel> Lista = new List<FilmeGetViewModel>();

                foreach (var filme in filmes) 
                {
                    Lista.Add(new FilmeGetViewModel
                    {
                        Id = filme.Id,
                        Titulo= filme.Titulo,
                        AnoLancamento = filme.AnoLancamento,
                        EstrelasAvaliacao = filme.EstrelasAvaliacao,
                        Plot = filme.Plot,
                        DuracaoFilme= filme.DuracaoFilme,
                        Diretor = filme.Diretor.PrimeiroNome,
                        TItuloCategoria = filme.Genero.NomeGenero
                    });
                }


                return Ok(Lista);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
            
        }

        [HttpGet(template:"{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> ListarUm(int id)
        {
            try 
            {
                var escolhido = await _context.Filmes
                        .AsNoTracking()
                        .Include(x=>x.Diretor)
                        .Include(x=>x.Genero)
                        .FirstOrDefaultAsync();

                if(escolhido == null)
                    return NotFound("Usuário não encontrado");

                var retorno = new FilmeGetViewModel
                {
                    Id = escolhido.Id,
                    Titulo = escolhido.Titulo,
                    AnoLancamento = escolhido.AnoLancamento,
                    EstrelasAvaliacao = escolhido.EstrelasAvaliacao,
                    Plot = escolhido.Plot,
                    DuracaoFilme = escolhido.DuracaoFilme,
                    Diretor = escolhido.Diretor.PrimeiroNome,
                    TItuloCategoria = escolhido.Genero.NomeGenero
                };

                return Ok(retorno);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] FilmePostOrPutViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Modelo informado incorreto");

                var filme = new Filme
                {
                    Titulo = model.Titulo,
                    AnoLancamento = DateTime.Now,
                    EstrelasAvaliacao = model.EstrelasAvaliacao,
                    Plot = model.Plot,
                    DuracaoFilme = model.DuracaoFilme,
                    DiretorId = model.DiretorId,
                    GeneroId = model.CategoriaID
                };

                await _context.Filmes.AddAsync(filme);
                await _context.SaveChangesAsync();

                return Ok(filme);

                 
            }catch(Exception ex) { return BadRequest(ex.Message); }
        }


        [HttpPut(template:"{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FilmePostOrPutViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Modelo invalido");

                var escolhido = await _context.Filmes
                        .AsNoTracking()
                        .Include(x => x.Diretor)
                        .Include(x => x.Genero)
                        .FirstOrDefaultAsync(x => x.Id == id);

                if (escolhido == null)
                    NotFound("Registro não encontrado");

                escolhido.Titulo = model.Titulo;
                escolhido.EstrelasAvaliacao = model.EstrelasAvaliacao;
                escolhido.Plot = model.Plot;
                escolhido.DuracaoFilme = model.DuracaoFilme;
                escolhido.DiretorId = model.DiretorId;
                escolhido.GeneroId = model.CategoriaID;

                _context.Filmes.Update(escolhido);
                await _context.SaveChangesAsync();

                return Ok(escolhido);


            }
            catch(Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete(template:"{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            try
            {
                var escolhido = await _context.Filmes
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == id);

                if (escolhido == null)
                    return NotFound("Registro não encontrado");

                _context.Filmes.Remove(escolhido);
                return Ok(escolhido);
            }
            catch(Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
