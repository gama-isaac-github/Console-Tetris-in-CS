using System;
using Tetris.Models.FuncoesDeMapa;
using Tetris.Models.Tetriminos;
using Tetris.Models.GameMetrics;

internal class TetrisInCS
{
    private static Random randomNumberGenerator = new Random();

    private static void Main()
    {
        Mapa mapa = new Mapa(25, 15);
        Tetrimino tetriminoEmUso = GerarNovoTetrimino(mapa);
        Pontuacao contadorDePontos = new();

        while (true)
        {
            if (!mapa.CaractereExiste(Tetrimino.TETRIMINO))
            {
                tetriminoEmUso = GerarNovoTetrimino(mapa);
            }

            if(mapa.VerificarGameOver()) break;
            mapa.ImprimirMapa();
            contadorDePontos.ImprimirPontuacao();
            tetriminoEmUso.MoverTetrimino(Console.ReadKey(true));
            tetriminoEmUso.FallTetrimino();
            mapa.VerificarLinhasConcluidas(contadorDePontos);
            Console.Clear();
        }

        FimDeJogo(contadorDePontos);
    }

    private static void FimDeJogo(Pontuacao contadorDePontos)
    {
        Console.WriteLine($"**********************************************************");
        Console.WriteLine($"Fim de Jogo! Você fez: {contadorDePontos.Pontos} pontos");
        Console.WriteLine($"**********************************************************");
        Console.WriteLine();
        Console.Write("Pressione R para jogar novamente e qualquer outra tecla para sair");
        var tecla = Console.ReadKey(true);
        if(tecla.Key == ConsoleKey.R) Main();
    }

    private static Tetrimino GerarNovoTetrimino(Mapa mapa)
    {
        List<Tetrimino> novosTetriminos = new(){new OTetrimino(mapa), new LTetrimino(mapa), new TTetrimino(mapa)};

        Tetrimino tetrimino = novosTetriminos[randomNumberGenerator.Next(3)];
        tetrimino.SpawnTetrimino();
        return tetrimino;
    }
}