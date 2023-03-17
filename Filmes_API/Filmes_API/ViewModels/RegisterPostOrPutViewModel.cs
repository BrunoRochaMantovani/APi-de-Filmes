using Filmes_API.Models;

namespace Filmes_API.ViewModels
{
    public class RegisterPostOrPutViewModel
    {
        public string Nome { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public int Papel { get; set; }
    }
}
