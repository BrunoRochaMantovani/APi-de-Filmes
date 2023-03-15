using Filmes_API.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Filmes_API.ViewModels
{
    public class FilmeGetViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public DateTime AnoLancamento { get; set; }

        public int EstrelasAvaliacao { get; set; }

        public string Plot { get; set; }

        public int DuracaoFilme { get; set; }

        public string Diretor { get; set; }
        public string TItuloCategoria { get; set; }


    }
}
