using System;
using Tetris.Models.Tetriminos;
using Tetris.Models.GameMetrics;

namespace Tetris.Models.FuncoesDeMapa;

internal class Mapa
{
    public const char VAZIO = '.';
    public char[,] mapaMatriz;

    public Mapa(int altura, int largura)
    {
        // Inicializa o mapa
        mapaMatriz = new char[altura, largura];

        for (int i = 0; i < mapaMatriz.GetLength(0); i++)
        {
            for (int j = 0; j < mapaMatriz.GetLength(1); j++)
            {
                mapaMatriz[i, j] = Mapa.VAZIO;
            }
        }
    }

    public void ImprimirMapa()
    {
        for (int i = 0; i < mapaMatriz.GetLength(0); i++)
        {
            for (int j = 0; j < mapaMatriz.GetLength(1); j++)
            {
                Console.Write(mapaMatriz[i, j]);
            }
            Console.WriteLine();
        }
    }

    public bool CaractereExiste(char caractere)
    {
        bool existe = false;

        for (int i = 0; i < mapaMatriz.GetLength(0); i++)
        {
            for (int j = 0; j < mapaMatriz.GetLength(1); j++)
            {
                if(mapaMatriz[i, j] == caractere) existe = true;
            }
        }

        return existe;
    }

    private void LimparLinha(int linha)
    {
        // Limpa a linha
        for(int i = 0; i < mapaMatriz.GetLength(1); i++)
        {
            mapaMatriz[linha, i] = VAZIO;
        }

        // Faz todos os tetriminos mortos acima da linha "caírem"
        for(int i = linha; i > 1; i--)
        {
            for(int j = 0; j < mapaMatriz.GetLength(1); j++)
            {
                mapaMatriz[i, j] = mapaMatriz[i - 1, j];
            }
        }
    }

    public void VerificarLinhasConcluidas(Pontuacao pontuacao)
    {
        int linhasCompletas = 0;
        
        for(int i = 0; i < mapaMatriz.GetLength(0); i++)
        {
            bool linhaCompleta = true;
            
            for(int j = 0; j < mapaMatriz.GetLength(1); j++)
            {
                if(mapaMatriz[i, j] != Tetrimino.DEAD_TETRIMINO)
                {
                    linhaCompleta = false;
                }
            }

            if(linhaCompleta)
            {
                LimparLinha(i);
                linhasCompletas++;
            }
        }

        pontuacao.AdicionarPontos(linhasCompletas);
    }

    public bool VerificarGameOver()
    {
        bool gameOver = false;

        for(int i = 0; i < mapaMatriz.GetLength(1); i++)
        {
            if(mapaMatriz[0, i] == Tetrimino.DEAD_TETRIMINO) gameOver = true;
        }

        return gameOver;
    }
}