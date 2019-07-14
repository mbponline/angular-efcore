using System;

namespace GameTop
{
    public class Jogador
    {
        private readonly string _Nome;

        public Jogador(string Nome)
        {
            _Nome = Nome;

        }

        public void Chuta()
        {
            Console.Write($"{_Nome} está chutando.\n");
        }
        public void Corre()
        {
            Console.Write($"{_Nome} está corendo.\n");

        }
        public void Pula()
        {
            Console.Write($"{_Nome} está pulando.\n");

        }
    }
}