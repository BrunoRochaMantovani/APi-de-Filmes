using System.Security.Principal;

namespace Filmes_API.Models
{
    public class Papel
    {
        public int Id { get; set; }
        public string TipoPapel { get; set; }

        public List<User> Users { get; set; }
    }
}