using System;
using GameTop.Interface;

namespace GameTop
{
    public class JogoFODA
    {
        private readonly IJogador _jogador1;
        private readonly IJogador _jogador2;

        public JogoFODA(IJogador jogador1, IJogador jogador2)
        {
            _jogador1 = jogador1;
            _jogador2 = jogador2;
        }
        public void IniciarJogo()
        {
            System.Console.Write(_jogador1.Chuta());
            System.Console.Write(_jogador1.Corre());
            System.Console.Write(_jogador1.Pula());

            System.Console.Write(_jogador2.Chuta());
            System.Console.Write(_jogador2.Corre());
            System.Console.Write(_jogador2.Pula());
        }
    }
}