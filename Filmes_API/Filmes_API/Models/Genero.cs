namespace Filmes_API.Models
{
    public class Genero
    {
        public int Id { get; set; }
        public string NomeGenero { get; set; }

        public List<Filme> Filmes { get; set; }
        public int FilmeId { get; set; }
    }
}
