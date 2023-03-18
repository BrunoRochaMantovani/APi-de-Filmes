using System.Drawing.Printing;

namespace Filmes_API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public List<Papel> Papel { get; set; }
    }
}
