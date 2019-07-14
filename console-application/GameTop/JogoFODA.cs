using System;
namespace GameTop
{
    public class JogoFODA
    {
        private readonly Jogador _jogador;
        public JogoFODA(Jogador jogador)
        {
            _jogador = jogador;
        }
        public void IniciarJogo()
        {
            _jogador.Chuta();
            _jogador.Corre();
            _jogador.Pula();
        }
    }
}