namespace GameTop
{
    class Program
    {
        static void Main(string[] args)
        {
           var jogo = new JogoFODA( new Jogador ("Alisson"));
           jogo.IniciarJogo();
        }
    }
}
