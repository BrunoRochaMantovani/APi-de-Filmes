namespace Filmes_API.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime AnoLancamento{ get; set; }

        public int EstrelasAvaliacao { get; set; }
        public string Plot { get; set; }
        public int DuracaoFilme { get; set; }
    }
}
