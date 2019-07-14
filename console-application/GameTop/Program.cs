
using GameTop.Lib;

namespace GameTop
{
    class Program
    {
        static void Main(string[] args)
        {
           var jogo = new JogoFODA( new Jogador1 ("Alisson"), new Jogador2("Alberto"));
           jogo.IniciarJogo();
        }
    }
}
