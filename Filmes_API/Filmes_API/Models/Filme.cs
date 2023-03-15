using System.ComponentModel.DataAnnotations.Schema;

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
   
        public Genero Genero { get; set; }
        public int GeneroId { get; set; }



    }
}
