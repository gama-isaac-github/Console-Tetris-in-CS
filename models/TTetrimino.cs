using System;
using Tetris.Models.FuncoesDeMapa;

namespace Tetris.Models.Tetriminos;

internal class TTetrimino : Tetrimino
{
    public TTetrimino(Mapa mapa) : base(mapa)
    {
        //this.SpawnTetrimino();   
    }

    public override void SpawnTetrimino()
    {
        Random randomNumberGenerator = new Random();

        int coordenadaPorRotacao = randomNumberGenerator.Next(3);

        // Define as coordendas de spawn do Tetrimino, varia de acordo com a classe derivada
        switch (coordenadaPorRotacao)
        {
            case 0:
                this.coordenadas = new int[,] { { 0, 6 }, { 0, 7 }, { 0, 8 }, { 1, 7 } };
                break;
            case 1:
                this.coordenadas = new int[,] { { 1, 6 }, { 1, 7 }, { 1, 8 }, { 0, 7 } };
                break;
            case 2:
                this.coordenadas = new int[,] { { 0, 6 }, { 1, 6 }, { 2, 6 }, { 1, 7 } };
                break;
            case 3:
                this.coordenadas = new int[,] { { 0, 7 }, { 1, 7 }, { 2, 7 }, { 1, 6 } };
                break;
        }

        base.SpawnTetrimino();
    }
}