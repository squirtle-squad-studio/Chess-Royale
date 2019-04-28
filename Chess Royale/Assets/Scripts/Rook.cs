using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessPiece
{
    protected override void Start()
    {
        base.Start();
        name = "Rook";

        for(int row = -7; row < 8; row++)
        {
            moves.Add(new Vector2Int(0, row));
        }
        for (int col = -7; col < 8; col++)
        {
            moves.Add(new Vector2Int(col, 0));
        }
    }
}
