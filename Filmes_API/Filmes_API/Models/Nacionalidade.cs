namespace Filmes_API.Models
{
    public class Nacionalidade
    {
        public int Id { get; set; }

        public string Pais { get; set; }

        public List<Diretor> Diretores { get; set; }
    }
}
