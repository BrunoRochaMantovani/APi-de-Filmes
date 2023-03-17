using Filmes_API.Data;
using Filmes_API.Models;
using Filmes_API.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Post([FromBody] RegisterPostOrPutViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Modelo informado incorreto");

                var user = new User 
                {
                    Nome = model.Nome,
                    Username = model.Username, 
                    Email = model.Email,
                    Password = model.Password,
                    PapelId = model.Papel
                };

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return Ok(user);

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost(template: "v1/accounts/login")]
        public async Task<IActionResult> Login()
        {
            try
            {

            }catch(Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
