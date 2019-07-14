using System;
using GameTop.Interface;

namespace GameTop.Lib
{
    public class Jogador2 : IJogador
    {
        private readonly string _Nome;

        public Jogador2(string Nome)
        {
            _Nome = Nome;

        }

       public string  Chuta()
        {
           return ($"{_Nome} está chutando.\n");            
        }

       public string Corre()
        {
         return   ($"{_Nome} está corendo.\n");
        }

      public  string  Pula()
        {
           return ($"{_Nome} está pulando.\n");
        }
    }
}