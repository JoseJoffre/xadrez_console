using System;
using tabuleiro;
using Xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {

            PartidaDeXadrez partida = new PartidaDeXadrez();

            while (!partida.terminada)
            {
                try
                {
                    Console.Clear();

                    Tela.imprimirPartida(partida);
                    

                    Console.WriteLine();
                    Console.Write("Digite a posição de Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                    partida.validarPosicaoDeOrigem(origem);

                    bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                    Console.Write("Digite a posição de Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                    partida.validarPosicaoDestino(origem, destino);

                    partida.realizaJogada(origem, destino);
                } catch(TabuleiroException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }  

            }

            Console.Clear();
            Tela.imprimirPartida(partida);



        }
       
    }
}
