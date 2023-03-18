using Filmes_API.Data;
using Filmes_API.Models;
using Filmes_API.Services;
using Filmes_API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Filmes_API.Controllers
{
    [ApiController]
    [Route("/v1/accounts/")]
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromServices] TokenService tokenService
            , [FromBody] LoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Modelo informado invalido");

                var user = await _context
                    .Users
                    .AsNoTracking()
                    .Include(x=>x.Papel)
                    .FirstOrDefaultAsync(x => x.Username == model.Username);

                if (user == null)
                    return NotFound("Usuário não encontrado");


                var token = tokenService.GenerateToken(user);
                return Ok(token);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
