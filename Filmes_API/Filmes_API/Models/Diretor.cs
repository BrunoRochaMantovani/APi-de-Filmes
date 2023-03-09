﻿namespace Filmes_API.Models
{
    public class Diretor
    {
        public int Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Nacionalidade { get; set; }

        public DateTime Data_Nascimento { get; set; }

        //PROPRIEDADES DE NAVEGAÇÃO

        public List<Filme> Filmes { get; set; }

    }
}
