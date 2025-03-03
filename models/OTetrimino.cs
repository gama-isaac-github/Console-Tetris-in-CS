using System;
using Tetris.Models.FuncoesDeMapa;

namespace Tetris.Models.Tetriminos;

internal class OTetrimino : Tetrimino
{
    public OTetrimino(Mapa mapa) : base(mapa)
    {
        //this.SpawnTetrimino();   
    }

    public override void SpawnTetrimino()
    {
        // Define as coordendas de spawn do Tetrimino, varia de acordo com a classe derivada
        this.coordenadas = new int[,] { {0, 7}, {0, 8}, {1, 7}, {1, 8} };

        base.SpawnTetrimino();
    }
}