﻿namespace Filmes_API.ViewModels
{
    public class DiretorPostOrPutViewModel
    {
        public int Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }

        public int NacionalidadeId { get; set; }
        public DateTime Data_Nascimento { get; set; }
    }
}
