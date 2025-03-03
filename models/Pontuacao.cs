using System;

namespace Tetris.Models.GameMetrics;

class Pontuacao
{
    public int Pontos { get; set; }
    private int pontosPorLinha = 10;

    public Pontuacao()
    {
        Pontos = 0;
    }

    public void ImprimirPontuacao()
    {
        Console.Write($"Pontuação: {Pontos}");
    }

    public void AdicionarPontos(int linhasCompletas)
    {
        Pontos += pontosPorLinha * linhasCompletas;
    }
}