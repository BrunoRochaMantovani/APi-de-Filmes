using Filmes_API.Data;
using Filmes_API.Models;
using Filmes_API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Filmes_API.Controllers
{

    [ApiController]
    [Route("/v1/diretor")]
    public class DiretorController : Controller
    {
        private readonly AppDbContext _context;

        public DiretorController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                var todos = await _context
                        .Diretores
                        .AsNoTracking()
                        .ToListAsync();

                List<DiretorGetViewModel> atorGetViewModels = new List<DiretorGetViewModel>();

                foreach (var obj in todos)
                {
                    var ator = new DiretorGetViewModel { Id = obj.Id, PrimeiroNome = obj.PrimeiroNome, UltimoNome = obj.UltimoNome, Nacionalidade = obj.Nacionalidade, Data_Nascimento = obj.Data_Nascimento };
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
                        .Diretores
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == id);

                if (escolhido == null)
                    return BadRequest("Usuario não encontrado");

                var diretor = new DiretorGetViewModel { Id = escolhido.Id, PrimeiroNome = escolhido.PrimeiroNome, UltimoNome = escolhido.UltimoNome, Nacionalidade = escolhido.Nacionalidade, Data_Nascimento = escolhido.Data_Nascimento };
                return Ok(diretor);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DiretorPostOrPutViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Modelo informado incorreto");

                var diretor = new Diretor
                {
                    PrimeiroNome = model.PrimeiroNome,
                    UltimoNome = model.UltimoNome,
                    Nacionalidade = model.Nacionalidade,
                    Data_Nascimento = model.Data_Nascimento
                };

                await _context.Diretores.AddAsync(diretor);
                await _context.SaveChangesAsync();
                return Ok(diretor);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut(template: "{id}")]
        public async Task<IActionResult> Put([FromBody] DiretorPostOrPutViewModel model, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Modelo informado incorreto");

                var diretor = await _context
                    .Diretores
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (diretor is null)
                    return NotFound("Usuário não encontrado");

                diretor.PrimeiroNome = model.PrimeiroNome;
                diretor.UltimoNome = model.UltimoNome;
                diretor.Nacionalidade = model.Nacionalidade;
                diretor.Data_Nascimento = model.Data_Nascimento;


                _context.Diretores.Update(diretor);
                await _context.SaveChangesAsync();
                return Ok(diretor);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete(template: "{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var diretor = await _context
                    .Diretores
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (diretor is null)
                    return NotFound("Usuário não encontrado");

                _context.Diretores.Remove(diretor);
                await _context.SaveChangesAsync();
                return Ok(diretor);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
