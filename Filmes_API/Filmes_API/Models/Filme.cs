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

        //PROPRIEDADES DE NAVEGAÇÃO
        public Diretor Diretor { get; set; }
        public int DiretorId { get; set; }

        public List<Ator> Atores { get; set; }

        public List<Genero> Generos { get; set; }


    }
}
