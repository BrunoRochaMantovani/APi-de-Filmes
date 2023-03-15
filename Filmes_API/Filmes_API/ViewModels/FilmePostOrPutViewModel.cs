namespace Filmes_API.ViewModels
{
    public class FilmePostOrPutViewModel
    {
        public string Titulo { get; set; }

        public int EstrelasAvaliacao { get; set; }

        public string Plot { get; set; }

        public int DuracaoFilme { get; set; }

        public int DiretorId { get; set; }
        public int CategoriaID { get; set; }
    }
}
