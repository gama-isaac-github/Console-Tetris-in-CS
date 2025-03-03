using System;
using Tetris.Models.FuncoesDeMapa;

namespace Tetris.Models.Tetriminos;

internal class Tetrimino
{
    public const char TETRIMINO = '#';
    public const char DEAD_TETRIMINO = '%';
    public const char VAZIO = '.';
    public int[,] coordenadas;
    Mapa mapa;

    public Tetrimino(Mapa mapa)
    {
        this.mapa = mapa;
    }

    public virtual void SpawnTetrimino()
    {
        // Insere o tetrimino no mapa
        for (int i = 0; i < coordenadas.GetLength(0); i++)
        {
            this.mapa.mapaMatriz[coordenadas[i, 0], coordenadas[i, 1]] = TETRIMINO;
        }
    }

    public void FallTetrimino()
    {
        int[,] novasCoordenadas = new int[coordenadas.GetLength(0), coordenadas.GetLength(1)];

        // Copia a matriz de coordenadas para a de novas coordenadas
        for (int i = 0; i < coordenadas.GetLength(0); i++)
        {
            for (int j = 0; j < coordenadas.GetLength(1); j++)
            {
                novasCoordenadas[i, j] = coordenadas[i, j];
            }
        }

        // Calcula as novas coordendas, somando 1 ao y
        for (int i = 0; i < novasCoordenadas.GetLength(0); i++)
        {
            novasCoordenadas[i, 0] += 1;
        }

        if (VerificarMovimentoInvalido(novasCoordenadas)) return;

        // Se o movimento foi possível, move o tetrimino
        for (int i = 0; i < coordenadas.GetLength(0); i++)
        {
            mapa.mapaMatriz[coordenadas[i, 0], coordenadas[i, 1]] = VAZIO;
        }

        for (int i = 0; i < novasCoordenadas.GetLength(0); i++)
        {
            mapa.mapaMatriz[novasCoordenadas[i, 0], novasCoordenadas[i, 1]] = TETRIMINO;
        }

        coordenadas = novasCoordenadas;
    }

    public void KillTetrimino()
    {
        // Substitui o corpo do tetrimino pelo char de tetrimino "morto"
        for (int i = 0; i < coordenadas.GetLength(0); i++)
        {
            this.mapa.mapaMatriz[coordenadas[i, 0], coordenadas[i, 1]] = DEAD_TETRIMINO;
        }
    }

    public void MoverTetrimino(ConsoleKeyInfo direcao)
    {
        int[,] novasCoordenadas = new int[coordenadas.GetLength(0), coordenadas.GetLength(1)];

        // Copia a matriz de coordenadas para a de novas coordenadas
        for (int i = 0; i < coordenadas.GetLength(0); i++)
        {
            for (int j = 0; j < coordenadas.GetLength(1); j++)
            {
                novasCoordenadas[i, j] = coordenadas[i, j];
            }
        }

        // Calcula as novas coordendas, somando 1 ao y
        for (int i = 0; i < novasCoordenadas.GetLength(0); i++)
        {
            novasCoordenadas[i, 1] += direcao.Key == ConsoleKey.LeftArrow ? -1 : direcao.Key == ConsoleKey.RightArrow ? 1 : 0;
        }

        if (VerificarMovimentoInvalido(novasCoordenadas)) return;

        // Se o movimento foi possível, move o tetrimino
        for (int i = 0; i < coordenadas.GetLength(0); i++)
        {
            mapa.mapaMatriz[coordenadas[i, 0], coordenadas[i, 1]] = VAZIO;
        }

        for (int i = 0; i < novasCoordenadas.GetLength(0); i++)
        {
            mapa.mapaMatriz[novasCoordenadas[i, 0], novasCoordenadas[i, 1]] = TETRIMINO;
        }

        coordenadas = novasCoordenadas;
    }

    private bool VerificarMovimentoInvalido(int[,] novasCoordenadas)
    {
        // Verifica se o movimento é possível
        for (int i = 0; i < novasCoordenadas.GetLength(0); i++)
        {
            // Se a nova coordenada está fora do mapa
            if (novasCoordenadas[i, 0] >= mapa.mapaMatriz.GetLength(0) || novasCoordenadas[i, 1] >= mapa.mapaMatriz.GetLength(1) ||
                     novasCoordenadas[i, 0] < 0 || novasCoordenadas[i, 1] < 0)
            {
                this.KillTetrimino();
                return true;
            }
            // Se a próxima posição for um tetrimino morto
            else if (mapa.mapaMatriz[novasCoordenadas[i, 0], novasCoordenadas[i, 1]] == DEAD_TETRIMINO)
            {
                this.KillTetrimino();
                return true;
            }
        }

        return false;
    }
}