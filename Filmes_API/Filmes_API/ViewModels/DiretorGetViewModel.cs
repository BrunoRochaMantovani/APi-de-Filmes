﻿namespace Filmes_API.ViewModels
{
    public class DiretorGetViewModel
    {
        public int Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string Nacionalidade { get; set; }
    }
}
